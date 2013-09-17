using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Editors
{
    public class PromouterEditor : BaseEditor
    {
        public PromouterEditor(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public void Edit(PromouterForm source, PromouterUser dest)
        {
            dest.Email = source.Email;
            dest.IsAdmin = source.IsAdmin;

            var mainAlbum = dest.Albums.First();
            if (source.NewPhotos != null)
            {
                foreach (var photo in source.NewPhotos)
                {
                    DataAccessLayer.Create(new Photo
                    {
                        Album = DataAccessLayer.GetById<Album>(mainAlbum.Id),
                        SourceUrl = ImageCreator.SavePhoto(photo)
                    });
                }
            }

            DataAccessLayer.ClearChecklist(dest.MainChecklist);

            foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.PromouterChecklistType.Id))
            {
                var attributeValue = new AttribValue
                {
                    Attrib = attribute,
                    AttribId = attribute.Id,
                    ChecklistId = dest.MainChecklist.Id
                };

                switch (attribute.Code)
                {
                    case Constants.DesiredWorkTimeCode:
                        attributeValue.Value = editDesiredWorkTime(source);
                        break;
                    case Constants.WorkCode:
                        attributeValue.Value = editDesiredWork(source);
                        break;
                    case Constants.WorkExperienceCode:
                        attributeValue.Value = editWorkExperience(source);
                        break;
                    case Constants.MobilePhoneCode:
                        attributeValue.Value = editPhone(source);
                        break;
                }

                dest.MainChecklist.AttrbuteValues.Add(attributeValue);
            }

            ValueFromAttributeConverter.AttributesFromModel(source, dest.MainChecklist.AttrbuteValues, DataAccessLayer);
        }

        private string editPhone(PromouterForm source)
        {
            var entityList = DataAccessLayer.Create(new EntityList { });
            if (source.Phone != null)
            {
                DataAccessLayer.Create(new PhoneNumber
                {
                    EntityList = entityList,
                    CountryCode = DataAccessLayer.Get<DictValue>(source.Phone.CountryCode),
                    Code = source.Phone.Code,
                    Number = source.Phone.Number,
                });
            }
            return entityList.Id.ToString();
        }

        private string editWorkExperience(PromouterForm source) 
        {
            var entityList = DataAccessLayer.Create(new EntityList { });
            if (source.WorkExperience != null)
            {
                foreach (var item in source.WorkExperience.OrderBy(x => x.CreationDate))
                {
                    DataAccessLayer.Create(new WorkExpirience
                    {
                        EntityList = entityList,
                        Start = item.StartTime,
                        End = item.EndTime,
                        Hours = item.Hours,
                        Title = item.Title,
                        WorkName = item.WorkName
                    });
                }
            }
            return entityList.Id.ToString();
        }

        private string editDesiredWorkTime(PromouterForm source)
        {
            var entityList = DataAccessLayer.Create(new EntityList { });
            if (source.DesiredWorkTime != null)
            {
                foreach (var item in source.DesiredWorkTime)
                {
                    DataAccessLayer.Create(new DesiredWorkTime
                    {
                        EntityList = entityList,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime,
                        DayOfWeek = int.Parse(item.DayOfWeek),
                    });
                }
            }
            return entityList.Id.ToString();
        }

        private string editDesiredWork(PromouterForm source)
        {
            var entityList = DataAccessLayer.Create(new EntityList { });
            if (source.DesiredWork != null)
            {
                foreach (var item in source.DesiredWork.Where(item => item.Value))
                {
                    DataAccessLayer.Create(new DesiredWork
                    {
                        EntityList = entityList,
                        Work = DataAccessLayer.Get<DictValue>(item.Code)
                    });
                }
            }
            return entityList.Id.ToString();
        }
    }
}