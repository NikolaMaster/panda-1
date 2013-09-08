﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
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
            throw new NotImplementedException();
        }

        public override void InverseLoad(PromouterUser source, PromouterForm dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;

            var counter = 0;
            
            var checklist = source.Checklists.FirstOrDefault();
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
                    case Constants.GenderCode:
                        dest.Gender = attrib.Value;
                        break;
                    case "Фамилия":
                        dest.LastName = attrib.Value;
                        break;
                    case "Имя":
                        dest.FirstName = attrib.Value;
                        break;
                    case "Отчество":
                        dest.MiddleName = attrib.Value;
                        break;
                    case Constants.DateOfBirthCode:
                        dest.BirthDate = dateTimeValue;
                        break;
                    case Constants.MedicalBookCode:
                        dest.MedicalBook = boolValue;
                        break;
                    case Constants.CarCode:
                        dest.Car = boolValue;
                        break;
                    case "Готов работать сейчас":
                        dest.Status = attrib.Value;
                        break;
                    case Constants.MobilePhoneCode:
                        dest.MobilePhone = stringValue;
                        break;
                    case Constants.SalaryCode:
                        dest.Salary = dictValue;
                        break;
                    case Constants.CityCode:
                        dest.City = stringValue;
                        break;
                    case Constants.EducationCode:
                        dest.Education = stringValue;
                        break;
                    case Constants.WorkExperienceCode:
                        getWorkExperience(new Guid(stringValue), dest);
                        break;
                    case Constants.HeightCode:
                        dest.Height = intValue;
                        break;
                    case Constants.BuildCode:
                        dest.Build = stringValue;
                        break;
                    case Constants.WeightCode:
                        dest.Weight = intValue;
                        break;
                    case Constants.SkinTypeCode:
                        dest.SkinType = stringValue;
                        break;
                    case Constants.EyeColorCode:
                        dest.EyeColor = stringValue;
                        break;
                    case Constants.HairColorCode:
                        dest.HairColor = stringValue;
                        break;
                    case Constants.HairLengthCode:
                        dest.HairLength = stringValue;
                        break;
                    case Constants.SizeClothesCode:
                        dest.SizeClothes = stringValue;
                        break;
                    case Constants.SizeShoesCode:
                        dest.SizeShoes = stringValue;
                        break;
                    case Constants.SizeChestCode:
                        dest.SizeChest = stringValue;
                        break;
                    case Constants.RollerSkatesCode:
                        dest.RollerSkates = boolValue;
                        break;
                    case Constants.WinterSkatesCode:
                        dest.WinterSkates = boolValue;
                        break;
                    case Constants.AboutCode:
                        dest.About = stringValue;
                        break;
                    case Constants.HobbiesCode:
                        dest.Hobbies = stringValue;
                        break;
                    case Constants.DesiredWorkCode:
                        getDesiredWork(new Guid(stringValue), dest);
                        break;
                    case Constants.DesiredWorkTimeCode:
                        getDesiredTimeOfWork(new Guid(stringValue), dest);
                        break;
                }
                #endregion
            }  
        }

        private void getWorkExperience(Guid entityId, PromouterForm dest)
        {
            dest.WorkExperience = DataAccessLayer.Get<WorkExpirience>(x => x.EntityList.Id == entityId)
                .OrderBy(x => x.Start.HasValue ? x.Start.Value.Ticks : long.MaxValue)
                .Select(x => new PromouterForm.WorkExperienceUnit
                {
                    Title = x.Title,
                    StartTime = x.Start,
                    EndTime = x.End,
                    Hours = x.Hours,
                    WorkName = x.WorkName,
                    Id = x.Id
                })
                
                .ToList();
        }

        private void getDesiredTimeOfWork(Guid entityId, PromouterForm dest)
        {
            dest.DesiredWorkTime = DataAccessLayer.Get<DesiredWorkTime>(x => x.EntityList.Id == entityId)
                .OrderBy(x => x.StartTime.HasValue ? x.StartTime.Value.Ticks : long.MaxValue)
                .Select(x => new PromouterForm.DesiredWorkTimeUnit
                {
                    Id = x.Id,
                    DayOfWeek = x.DayOfWeek.ToPandaString(),
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .ToList();

        }

        private void getDesiredWork(Guid entityId, PromouterForm dest)
        {
            dest.DesiredWork = DataAccessLayer.Get<DictGroup>(Constants.DesiredWorkCode)
                .DictValues
                .Select(x => new PromouterForm.DesiredWorkUnit
                {
                    Code = x.Code,
                    Title = x.Description,
                    Value = DataAccessLayer.Get<DesiredWork>(y => y.EntityList.Id == entityId && y.Work != null && y.Work.Id == x.Id).Any()
                })
                .ToList();
        }
    }
}