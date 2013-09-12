using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
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


        private void inverseMainParam(EmployerUser source, Employer dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.DaysOnSite = getDaysOnSite(source.CreationDate);
            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);

            dest.Status = getStatus(source);
            


            foreach (var attrib in source.MainChecklist.AttrbuteValues)
            {
                var checklist = source.MainChecklist;

                var dateTimeValue = DateTime.UtcNow;
                var stringValue = attrib.Value;
                var intValue = 0;
                var boolValue = true;
                string dictValue = null;

                DateTime.TryParse(stringValue, out dateTimeValue);
                int.TryParse(stringValue, out intValue);
                bool.TryParse(stringValue, out boolValue);
                if (attrib.Attrib.AttribType.DictGroup != null && attrib.Value != null)
                {
                    dictValue = DataAccessLayer.Get<DictValue>(attrib.Value).Description;
                }

                #region Big switch [TODO by code field]

                switch (attrib.Attrib.Code)
                {
                    case Constants.AboutCode:
                        dest.About = stringValue;
                        break;
                    case Constants.EmployerNameCode:
                        dest.EmployerName = stringValue;
                        break;
                    case Constants.AddressCode:
                        dest.Address = stringValue;
                        break;
                    case Constants.MobilePhoneCode:
                        dest.MobilePhone = stringValue;
                        break;
                    case Constants.CityCode:
                        dest.City = dictValue;
                        break;
                }
                #endregion
            }
        }

        private void inverseVacancy(EmployerUser source, Employer dest)
        {
            var checklists = source.Checklists.Where(x => x.ChecklistType.Code != Constants.EmployerMainChecklistTypeCode);
            var vacancyList = new List<Employer.VacancyUnit>();


            foreach (var checklist in checklists)
            {
                var vacancyUnit = new Employer.VacancyUnit();
                foreach (var attrib in checklist.AttrbuteValues)
                {
                    DateTime? dateTimeValue = null;
                    var stringValue = attrib.Value;
                    var intValue = 0;
                    var boolValue = true;
                    string dictValue = null;

                    DateTime dateTimeTmpValue;
                    if (DateTime.TryParse(stringValue, out dateTimeTmpValue))
                        dateTimeValue = dateTimeTmpValue;
                    int.TryParse(stringValue, out intValue);
                    bool.TryParse(stringValue, out boolValue);

                    if (attrib.Attrib.AttribType.DictGroup != null && attrib.Value != null)
                    {
                        dictValue = DataAccessLayer.Get<DictValue>(attrib.Value).Description;
                    }
                    #region Big switch [TODO by code field]

                    switch (attrib.Attrib.Code)
                    {
                        case Constants.SalaryCode:
                            vacancyUnit.Salary = dictValue;
                            break;
                        case Constants.WorkCode:
                            vacancyUnit.JobTitle = dictValue;
                            break;
                        case Constants.AboutCode:
                            vacancyUnit.FullDescription = stringValue;
                            break;
                        case Constants.StartWorkCode:
                            vacancyUnit.StartTime = dateTimeValue;
                            break;
                        case Constants.EndWorkCode:
                            vacancyUnit.EndTime = dateTimeValue;
                            break;
                        case Constants.CityCode:
                            vacancyUnit.City = dictValue;
                            break;
                    }

                    #endregion
                }

                vacancyList.Add(vacancyUnit);
            }


            dest.Vacancies = vacancyList;
        }

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
            inverseMainParam(source,dest);
            inverseVacancy(source, dest);
        }
    }
}