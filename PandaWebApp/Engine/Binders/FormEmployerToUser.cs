using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormEmployerToUser : BaseDataAccessLayerBinder<EmployerForm, EmployerUser>
    {
        public FormEmployerToUser(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {  
        }


        public override void Load(EmployerForm source, EmployerUser dest)
        {
            throw new NotImplementedException();
        }

        private void inverseMainParam(EmployerUser source, EmployerForm dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;

            dest.Albums = DataAccessLayer.Get<Album>(x => x.User.Id == source.Id)
                .Select(x => new AlbumUnit
                {
                    Id = x.Id,
                    Photos = x.Photos.ToList(),
                    Title = x.Name,
                })
                .ToList();

            var checklist = source.MainChecklist;
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

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
                    case Constants.AboutCode:
                        dest.About = stringValue;
                        break;
                    case Constants.EmployerNameCode:
                        dest.EmployerName = stringValue;
                        break;
                    case Constants.AddressCode:
                        dest.Address = stringValue;
                        break;
                    case Constants.ReadyForWorkCode:
                        dest.Status = attrib.Value;
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

        private void inverseVacancy(EmployerUser source, EmployerForm dest)
        {
            var checklists = source.Checklists.Where(x => x.ChecklistType.Code != Constants.EmployerMainChecklistTypeCode);
            var vacancyList = new List<EmployerForm.VacancyUnit>();

            var salaryValues = DataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? int.MaxValue : int.Parse(x.Text))
                .ToList();
            var workValues = DataAccessLayer.ListItemsFromDict(Constants.DesiredWorkCode);

            foreach (var checklist in checklists)
            {
                var vacancyUnit = new EmployerForm.VacancyUnit
                {
                    Id = checklist.Id,
                    SalaryValues = salaryValues,
                    WorkValues = workValues,
                    CreationDate = checklist.CreationDate,
                };
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
                            vacancyUnit.Salary = stringValue;
                            break;
                        case Constants.WorkCode:
                            vacancyUnit.Work = stringValue;
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
                            vacancyUnit.City = stringValue;
                            break;
                    }

                    #endregion
                }

                vacancyList.Add(vacancyUnit);
            }

            dest.Vacancies = vacancyList
                .OrderBy(x => x.CreationDate)
                .ToList();
        }

        public override void InverseLoad(EmployerUser source, EmployerForm dest)
        {
            inverseMainParam(source, dest);
            inverseVacancy(source, dest);
        }
    }
}