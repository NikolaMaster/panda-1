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

        private void inverseMainParam(EmployerUser source, Employer dest)
        {

            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.DaysOnSite = DateTime.UtcNow.Day - source.CreationDate.Day;

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


            foreach (var attrib in source.MainChecklist.AttrbuteValues)
            {
                var checklist = source.MainChecklist;

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
                        dest.City = stringValue;
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
                Employer.VacancyUnit eVacancyUnit = new Employer.VacancyUnit();
                foreach (var attrib in checklist.AttrbuteValues)
                {
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
                        case Constants.SalaryCode:
                            eVacancyUnit.Salary = dictValue;
                            break;
                        case Constants.DesiredWorkCode:
                            eVacancyUnit.JobTitle = dictValue;
                            break;
                        case Constants.AboutCode:
                            eVacancyUnit.FullDescription = stringValue;
                            break;
                        case Constants.StartWorkCode:
                            eVacancyUnit.StartTime = dateTimeValue;
                            break;
                        case Constants.EndWorkCode:
                            eVacancyUnit.EndTime = dateTimeValue;
                            break;
                        case Constants.CityCode:
                            eVacancyUnit.City = stringValue;
                            break;
                    }

                    #endregion
                }

                vacancyList.Add(eVacancyUnit);
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