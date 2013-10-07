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
            dest.Photo = source.Avatar == null ? WebConstants.NoPhoto : source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.IsAdmin = source.IsAdmin;
            dest.DaysOnSite = Extensions.GetDayOnSiteStatus(source.CreationDate);
            dest.FeedbackCount = DataAccessLayer.Count<Review>(x => x.RecieverId == source.Id);
            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);

            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList().OrderBy(x => x.LastHit);
            dest.Status = session.Any() ? Extensions.GetActivityStatus(session.Last().LastHit) : "Оффлайн";
            
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
            var vacancyList = new List<Vacancy>();
            var binder = new VacancyToChecklist(DataAccessLayer);
            foreach (var checklist in checklists)
            {
                var vacancy = new Vacancy();
                binder.InverseLoad(checklist, vacancy);
                vacancyList.Add(vacancy);
            }
            dest.Vacancies = vacancyList;
        }
    }
}