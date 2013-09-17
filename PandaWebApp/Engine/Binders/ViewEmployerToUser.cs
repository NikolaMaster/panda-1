using System;
using System.Collections.Generic;
using System.Linq;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class ViewEmployerToUser : BaseBinder<Employer, EmployerUser>
    {
        public DataAccessLayer DataAccessLayer { get; private set; }

        public ViewEmployerToUser(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }

        public override void Load(Employer source, EmployerUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        private string getDaysOnSite(DateTime dateCreation)
        {
            int h = (DateTime.UtcNow - dateCreation).Days;

            if (h == 0)
            {
                h++;
            }
            var days = new string[] { "дня", "дней", "день" };
            var ch = int.Parse(h.ToString().Last().ToString());
            string unit = string.Empty;

            if (ch == 1)
            {
                unit = days[2];
            }
            else if (ch > 4 && ch != 0)
            {
                unit = days[1];
            }
            else
            {
                unit = days[0];
            }

            return string.Format("{0} {1}", h, unit);
        }

        //i'm wrote this is very fast, so this method work is bad , sorry
        private string getStatus(EmployerUser source)
        {
            string status = string.Empty;
            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList();
            if (session.Any())
            {
                var minutes = new string[] { "минут", "минуты" };
                var hours = new string[] { "часа", "часов" };
                var days = new string[] { "дня", "дней" };

                int lastHit = Convert.ToInt32(Math.Round((DateTime.UtcNow - session.First().LastHit).TotalMinutes, 0));
                string unit = string.Empty;
                int ch = int.Parse(lastHit.ToString().Last().ToString());

                if (lastHit < 61)
                {
                    unit = ch > 4 && ch != 0 ? minutes[0] : minutes[1];
                }
                else if (lastHit > 60 && lastHit < 1440)
                {
                    unit = ch > 4 && ch != 0 ? hours[1] : hours[0];
                }
                else
                {
                    var h = (DateTime.UtcNow - session.First().LastHit).Days.ToString();
                    ch = int.Parse(h.Last().ToString());
                    unit = ch > 4 && ch != 0 ? days[1] : days[0];
                }

                status = lastHit < 5 ? "Онлайн" : string.Format("Был на сайте {0} {1} назад", lastHit, unit);
            }
            else
            {
                status = "Оффлайн";
            }

            return status;
        }

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.DaysOnSite = getDaysOnSite(source.CreationDate);
            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);
            dest.Status = getStatus(source);
            dest.Phone = new PhoneUnit();

            ValueFromAttributeConverter.ModelFromAttributes(dest, source.MainChecklist.AttrbuteValues, DataAccessLayer);
            foreach (var attrib in source.MainChecklist.AttrbuteValues)
            {
                switch (attrib.Attrib.Code)
                {
                    case Constants.MobilePhoneCode:
                        Guid entityListId;
                        if (Guid.TryParse(attrib.Value, out entityListId))
                        {
                            dest.Phone = DataAccessLayer.GetPhone(entityListId);
                        }
                        break;
                }
            }
            //vacancies
            var checklists = source.Checklists.Where(x => x.ChecklistType.Code != Constants.EmployerMainChecklistTypeCode);
            var vacancyList = new List<Employer.VacancyUnit>();

            foreach (var checklist in checklists)
            {
                var vacancyUnit = new Employer.VacancyUnit();
                ValueFromAttributeConverter.ModelFromAttributes(vacancyUnit, checklist.AttrbuteValues, DataAccessLayer);
                vacancyList.Add(vacancyUnit);
            }
            dest.Vacancies = vacancyList;
        }
    }
}