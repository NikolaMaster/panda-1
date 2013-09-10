using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
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

        private void clearChecklist(Checklist checklist)
        {
            foreach (var attrbuteValue in checklist.AttrbuteValues)
            {
                if (attrbuteValue.Attrib.AttribType.Type == typeof (EntityList).FullName)
                {
                    var entityListId = Guid.Parse(attrbuteValue.Value);
                    var entityList = DataAccessLayer.GetById<EntityList>(entityListId);
                    entityList.DesiredWork.Clear();
                    entityList.DesiredWorkTime.Clear();
                    entityList.WorkExpirience.Clear();
                    DataAccessLayer.Delete(entityList);
                }
            }   
            checklist.AttrbuteValues.Clear();
        }

        private string savePhoto(HttpPostedFileBase file)
        {
            var sourcePath = HttpContext.Current.Server.MapPath("/Content/img/");
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            file.SaveAs(Path.Combine(sourcePath, fileName));
            return "/Content/img/" + fileName;
        }

        public void Edit(PromouterForm source, PromouterUser dest)
        {
            var checklist = dest.Checklist;
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            var mainAlbum = dest.Albums.First();
            if (source.NewPhotos != null)
            {
                foreach (var photo in source.NewPhotos)
                {
                    DataAccessLayer.Create(new Photo
                    {
                        Album = DataAccessLayer.GetById<Album>(mainAlbum.Id),
                        SourceUrl = savePhoto(photo)
                    });
                }
            }


            clearChecklist(checklist);

            foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.PromouterChecklistType.Id))
            {
                var attributeValue = new AttribValue
                {
                    AttribId = attribute.Id,
                    ChecklistId = checklist.Id
                };

                #region Big switch [TODO by code field]
                switch (attribute.Code)
                {
                    case Constants.LastNameCode:
                        attributeValue.Value = source.LastName;
                        break;
                    case Constants.FirstNameCode:
                        attributeValue.Value = source.FirstName;
                        break;
                    case Constants.MiddleNameCode:
                        attributeValue.Value = source.MiddleName;
                        break;
                    case Constants.GenderCode:
                        attributeValue.Value = source.Gender;
                        break;
                    case Constants.DateOfBirthCode:
                        attributeValue.Value = source.BirthDate.ToPandaString();
                        break;
                    case Constants.MedicalBookCode:
                        attributeValue.Value = source.MedicalBook.ToString();
                        break;
                    case Constants.CarCode:
                        attributeValue.Value = source.Car.ToString();
                        break;
                    case Constants.ReadyForWorkCode:
                        attributeValue.Value = source.ReadyForWork.ToString();
                        break;
                    case Constants.MobilePhoneCode:
                        attributeValue.Value = source.MobilePhone;
                        break;
                    case Constants.SalaryCode:
                        attributeValue.Value = source.Salary;
                        break;
                    case Constants.CityCode:
                        attributeValue.Value = source.City;
                        break;
                    case Constants.EducationCode:
                        attributeValue.Value = source.Education;
                        break;
                    case Constants.WorkExperienceCode:
                        attributeValue.Value =  editWorkExperience(source);
                        break;
                    case Constants.HeightCode:
                        attributeValue.Value = source.Height.ToPandaString();
                        break;
                    case Constants.BuildCode:
                        attributeValue.Value = source.Build;
                        break;
                    case Constants.WeightCode:
                        attributeValue.Value = source.Weight.ToString(CultureInfo.InvariantCulture);
                        break;
                    case Constants.SkinTypeCode:
                        attributeValue.Value = source.SkinType;
                        break;
                    case Constants.EyeColorCode:
                        attributeValue.Value = source.EyeColor;
                        break;
                    case Constants.HairColorCode:
                        attributeValue.Value = source.HairColor;
                        break;
                    case Constants.HairLengthCode:
                        attributeValue.Value = source.HairLength;
                        break;
                    case Constants.SizeClothesCode:
                        attributeValue.Value = source.SizeClothes;
                        break;
                    case Constants.SizeShoesCode:
                        attributeValue.Value = source.SizeShoes;
                        break;
                    case Constants.SizeChestCode:
                        attributeValue.Value = source.SizeChest;
                        break;
                    case Constants.RollerSkatesCode:
                        attributeValue.Value = source.RollerSkates.ToString();
                        break;
                    case Constants.WinterSkatesCode:
                        attributeValue.Value = source.WinterSkates.ToString();
                        break;
                    case Constants.AboutCode:
                        attributeValue.Value = source.About;
                        break;
                    case Constants.HobbiesCode:
                        attributeValue.Value = source.Hobbies;
                        break;
                    case Constants.DesiredWorkTimeCode:
                        attributeValue.Value = editDesiredWorkTime(source);
                        break;
                    case Constants.DesiredWorkCode:
                        attributeValue.Value = editDesiredWork(source);
                        break;
                }
                #endregion

                checklist.AttrbuteValues.Add(attributeValue);
            }
        }

        private string editWorkExperience(PromouterForm source) 
        {
            var entityList = DataAccessLayer.Create(new EntityList { });
            if (source.WorkExperience != null)
            {
                foreach (var item in source.WorkExperience)
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