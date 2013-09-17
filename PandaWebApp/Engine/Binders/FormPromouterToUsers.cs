using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormPromouterToUsers : BaseDataAccessLayerBinder<PromouterForm, PromouterUser>
    {
        public FormPromouterToUsers(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {  
        }

        public override void Load(PromouterForm source, PromouterUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(PromouterUser source, PromouterForm dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;
            dest.IsAdmin = source.IsAdmin;
            dest.WorkExperience = new List<PromouterForm.WorkExperienceUnit>();
            dest.DesiredWorkTime = new List<PromouterForm.DesiredWorkTimeUnit>();
            dest.DesiredWork = new List<PromouterForm.DesiredWorkUnit>();

            dest.Albums =  DataAccessLayer.Get<Album>(x => x.User.Id == source.Id)
                .Select(x => new AlbumUnit
                {
                    Id = x.Id,
                    Photos = x.Photos.ToList(),
                    Title = x.Name,
                })
                .ToList();

            var checklist = source.MainChecklist;
            if (source.MainChecklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            ValueFromAttributeConverter.ModelFromAttributes(dest, checklist.AttrbuteValues, DataAccessLayer);
            foreach (var attrib in checklist.AttrbuteValues)
            {
                var stringValue = attrib.Value;
                switch (attrib.Attrib.Code)
                {
                    case Constants.WorkExperienceCode:
                        getWorkExperience(stringValue, dest);
                        break;
                    case Constants.DesiredWorkCode:
                        getDesiredWork(stringValue, dest);
                        break;
                    case Constants.DesiredWorkTimeCode:
                        getDesiredTimeOfWork(stringValue, dest);
                        break;
                    case Constants.MobilePhoneCode:
                        Guid entityListId;
                        if (Guid.TryParse(attrib.Value, out entityListId))
                        {
                            dest.Phone = DataAccessLayer.GetPhone(entityListId);
                        }
                        break;
                }
            }  
        }

        private void getWorkExperience(string value, PromouterForm dest)
        {
            if (string.IsNullOrEmpty(value)) 
                return;

            var entityId = Guid.Parse(value);

            dest.WorkExperience = DataAccessLayer.Get<WorkExpirience>(x => x.EntityList.Id == entityId)
                .OrderBy(x => x.CreationDate)
                .Select(x => new PromouterForm.WorkExperienceUnit
                {
                    Title = x.Title,
                    StartTime = x.Start,
                    EndTime = x.End,
                    Hours = x.Hours,
                    WorkName = x.WorkName,
                    Id = x.Id,
                    CreationDate = x.CreationDate
                })
                .ToList();
        }

        private void getDesiredTimeOfWork(string value, PromouterForm dest)
        {
            if (string.IsNullOrEmpty(value)) 
                return;

            var entityId = Guid.Parse(value);

            dest.DesiredWorkTime = DataAccessLayer.Get<DesiredWorkTime>(x => x.EntityList.Id == entityId)
                .OrderBy(x => x.CreationDate)
                .Select(x => new PromouterForm.DesiredWorkTimeUnit
                {
                    Id = x.Id,
                    DayOfWeek = x.DayOfWeek.ToPandaString(),
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    CreationDate = x.CreationDate
                })
                .ToList();
        }

        private void getDesiredWork(string value, PromouterForm dest)
        {
            if (string.IsNullOrEmpty(value)) 
                return;

            var entityId = Guid.Parse(value);

            dest.DesiredWork = DataAccessLayer.Get<DictGroup>(Constants.WorkCode)
                .DictValues
                .Select(x => new PromouterForm.DesiredWorkUnit
                {
                    Code = x.Code,
                    Title = x.Description,
                    Value =
                        DataAccessLayer.Get<DesiredWork>(
                            y => y.EntityList.Id == entityId && y.Work != null && y.Work.Id == x.Id).Any()
                })
                .ToList();
        }
    }
}
