using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
            dest.UserId = source.Id;
            dest.Email  = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl; 
            dest.Number = source.Number;
            dest.City = source.City;
            dest.DaysOnSite = DateTime.UtcNow.Day - source.CreationDate.Day;
            dest.MobilePhone = source.Phone;

            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);


            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id);
            if (session.Any())
            {
                var lastHit = Math.Round((DateTime.UtcNow - session.First().LastHit).TotalMinutes, 0);
                dest.Status = Equals(lastHit, 0) ? "Онлайн" : string.Format("Был на сайте {0} минут назад", lastHit);
            }
            else
            {
                dest.Status = "Оффлайн";
            }

            var checklist = source.Checklists.FirstOrDefault();

            foreach (var attrib in checklist.AttrbuteValues)
            {
                var dateTimeValue = DateTime.UtcNow;
                var stringValue = attrib.Value;
                var intValue = 0;
                var boolValue = true;

                DateTime.TryParse(stringValue, out dateTimeValue);
                int.TryParse(stringValue, out intValue);
                bool.TryParse(stringValue, out boolValue);

                #region Big switch [TODO by code field]
                switch (attrib.Attrib.Code)
                {
                    case "Мобильный телефон":
                        dest.MobilePhone = stringValue;
                        break;
                    case "О себе":
                        dest.About = stringValue;
                        break;
                    case Constants.CompanyNameCode:
                        dest.CompanyName = stringValue;
                        break;
                    case "Адрес":
                        dest.Address = stringValue;
                        break;
                    case Constants.VacancyCode:
                        getVacancy(new Guid(stringValue), dest);
                        break;
                }
                #endregion
            }
        }

        private void getVacancy(Guid id,Employer dest)
        {
            
            var vacancies = DataAccessLayer.Get<Vacancy>(
                x => x.EntityList.Id == id);
            var vacancyList = new List<Employer.VacancyUnit>();

            
            foreach (var vacancy in vacancies)
            {
                vacancyList.Add
                    (
                    new Employer.VacancyUnit()
                        {
                            //Title = vacancy.Work.Description,
                            StartTime = vacancy.StartTime.ToPandaString(),
                            EndTime = vacancy.EndTime.ToPandaString(),
                            FullDescription = vacancy.WorkDescription,
                            CostOfHours = int.Parse(DataAccessLayer.Get<DictValue>(vacancy.CostOfHours).Description),
                            //WorkName = vacancy.Work.Description
                        }
                    );
            }

            dest.Vacancies = vacancyList;
        }
    }
}