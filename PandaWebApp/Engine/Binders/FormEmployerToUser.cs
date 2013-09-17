using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(EmployerUser source, EmployerForm dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;
            dest.IsAdmin = source.IsAdmin;

            dest.Albums = DataAccessLayer.Get<Album>(x => x.User.Id == source.Id)
                .Select(x => new AlbumUnit
                {
                    Id = x.Id,
                    Photos = x.Photos.ToList(),
                    Title = x.Name,
                })
                .ToList();

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
            var vacancyList = new List<EmployerForm.VacancyUnit>();

            foreach (var checklist in checklists)
            {
                var vacancyUnit = new EmployerForm.VacancyUnit();
                ValueFromAttributeConverter.ModelFromAttributes(vacancyUnit, checklist.AttrbuteValues, DataAccessLayer);
                vacancyUnit.CreationDate = checklist.CreationDate;
                vacancyUnit.Id = checklist.Id;
                vacancyList.Add(vacancyUnit);
            }
            dest.Vacancies = vacancyList
                .OrderBy(x => x.CreationDate)
                .ToList();
        }
    }
}