using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewPromouterToUsers : BaseDataAccessLayerBinder<Promouter, PromouterUser>
    {

        public ViewPromouterToUsers(DataAccessLayer dataAccessLayer) 
            : base(dataAccessLayer)
        {
        }

        public override void Load(Promouter source, PromouterUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(PromouterUser source, Promouter dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar == null ? string.Empty : source.Avatar.SourceUrl; 
            dest.Number = source.Number;
            dest.DesiredWork1 = new List<string>();
            dest.DesiredWork2 = new List<string>();
            dest.WorkExperience1 = new List<Promouter.WorkExperienceUnit>();
            dest.WorkExperience2 = new List<Promouter.WorkExperienceUnit>();
            dest.DesiredWorkTime = new List<Promouter.TimeOfWorkUnit>();
            dest.DaysOnSite = DateTime.UtcNow.Day - source.CreationDate.Day;

            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList();
            if (session.Any())
            {
                var lastHit = Math.Round((DateTime.UtcNow - session.First().LastHit).TotalMinutes, 0);
                dest.Status = Equals(lastHit, 0) ? "Онлайн" : string.Format("Был на сайте {0} минут назад",lastHit);
            }
            else
            {
                dest.Status = "Оффлайн";
            }


            //get main album
            var firstOrDefault = source.Albums.FirstOrDefault(x => x.Name == "Основной альбом");
            if (firstOrDefault != null)
                dest.Album = firstOrDefault.Photos.Select(x => x.SourceUrl);

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
                    case Constants.GenderCode:
                        dest.Gender = dictValue;
                        break;
                    case Constants.LastNameCode:
                        dest.LastName = attrib.Value;
                        break;
                    case Constants.FirstNameCode:
                        dest.FirstName = attrib.Value;
                        break;
                    case Constants.MiddleNameCode:
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
                    case Constants.ReadyForWorkCode:
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
                    case Constants.WorkExperienceCode:
                        getWorkExperience(stringValue, dest);
                        break;
                    case Constants.DesiredWorkCode:
                        getDesiredWork(stringValue, dest);
                        break;
                    case Constants.DesiredWorkTimeCode:
                        getDesiredTimeOfWork(stringValue, dest);
                        break;
                }
                #endregion
            }
        }

        private void getDesiredWork(string value, Promouter dest)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var entityId = Guid.Parse(value);
                var desiredWorks = DataAccessLayer.Get<DesiredWork>(
                    x => x.EntityList.Id == entityId);

                var listWorks = new List<string>();
                foreach (var desiredWork in desiredWorks)
                {
                    listWorks.Add(desiredWork.Work.Description);
                }
                dest.DesiredWork1 = listWorks;
                dest.DesiredWork2 = new List<string>();
            }

        }

        private void getDesiredTimeOfWork(string value, Promouter dest)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var entityId = Guid.Parse(value);
                var desiredWorkTimes = DataAccessLayer.Get<DesiredWorkTime>(x => x.EntityList.Id == entityId);
                var sortedDictionary = new SortedDictionary<int, List<string>>();

                foreach (var desiredWorkTime in desiredWorkTimes)
                {
                    //TODO: fix this code
                    /*
                var time = string.Format("с {0}:{1} до {2}:{3}", desiredWorkTime.StartTime.TimeOfDay.Hours,desiredWorkTime.StartTime.TimeOfDay.Minutes,
                                         desiredWorkTime.EndTime.TimeOfDay.Hours, desiredWorkTime.EndTime.TimeOfDay.Minutes);
                 *      */
                    var time = string.Format("с {0} по {1}", desiredWorkTime.StartTime.ToPandaString(),
                        desiredWorkTime.EndTime.ToPandaString());

                    if (!sortedDictionary.ContainsKey(desiredWorkTime.DayOfWeek))
                    {
                        sortedDictionary.Add(desiredWorkTime.DayOfWeek, new List<string>() {time});
                    }
                    else
                    {
                        sortedDictionary[desiredWorkTime.DayOfWeek].Add(time);
                    }
                }

                var timeOfWorkUnits = new List<Promouter.TimeOfWorkUnit>();
                foreach (var iter in sortedDictionary)
                {
                    switch (iter.Key)
                    {
                        case 0:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Понедельник",
                                Time = iter.Value
                            });
                            break;
                        case 1:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Вторник",
                                Time = iter.Value
                            });
                            break;
                        case 2:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Среда",
                                Time = iter.Value
                            });
                            break;
                        case 3:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Четверг",
                                Time = iter.Value
                            });
                            break;
                        case 4:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Пятница",
                                Time = iter.Value
                            });
                            break;
                        case 5:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Суббота",
                                Time = iter.Value
                            });
                            break;
                        case 6:
                            timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit
                            {
                                Day = "Воскресенье",
                                Time = iter.Value
                            });
                            break;
                    }
                }
                dest.DesiredWorkTime = timeOfWorkUnits;
            }
        }

        private void getWorkExperience(string value, Promouter dest)
        {

            if (!string.IsNullOrEmpty(value))
            {
                var entityId = Guid.Parse(value);
                var allWorkExperience = DataAccessLayer.Get<WorkExpirience>(x => x.EntityList.Id == entityId)
                    .Select(x => new Promouter.WorkExperienceUnit
                    {
                        Title = x.Title,
                        StartTime = x.Start.HasValue ? x.Start.Value.ToPandaString() : null,
                        EndTime = x.End.HasValue ? x.End.Value.ToPandaString() : null,
                        Hours = x.Hours, // (expirience.Start - expirience.End).Hours,
                        WorkName = x.WorkName,
                    }).ToList();

                var countExperience = 0;
                var experienceUnits1 = new List<Promouter.WorkExperienceUnit>();
                var experienceUnits2 = new List<Promouter.WorkExperienceUnit>();
                foreach (var expirience in allWorkExperience)
                {
                    if (countExperience >= allWorkExperience.Count()/2)
                    {
                        experienceUnits1.Add(expirience);
                    }
                    else
                    {
                        experienceUnits2.Add(expirience);
                    }
                    countExperience++;
                }
                dest.WorkExperience1 = experienceUnits1;
                dest.WorkExperience2 = experienceUnits2;
            }
        }
    }
}