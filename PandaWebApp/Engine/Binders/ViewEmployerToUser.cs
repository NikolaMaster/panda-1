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

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.DaysOnSite = Extensions.GetDayOnSiteStatus(source.CreationDate);
            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);


            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList();
            dest.Status = session.Any() ? Extensions.GetActivityStatus(session.First().LastHit) : "Оффлайн";
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