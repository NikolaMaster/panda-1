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

        private string getDaysOnSite(DateTime dateCreation)
        {
            int h = (DateTime.UtcNow - dateCreation).Days;

            if (h == 0)
            {
                h++;
            }
            var days = new string[] {"дня", "дней", "день"};
            var ch = int.Parse(h.ToString().Last().ToString());
            string unit = string.Empty;

            if (ch == 1)
            {
                unit = days[2];
            }
            else if (ch > 4 && ch != 0)
            {
                unit = days[1];
            }
            else
            {
                unit = days[0];
            }

            return string.Format("{0} {1}", h, unit);
        }

        private string getStatus(PromouterUser source)
        {
            string status = string.Empty;
            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList();
            if (session.Any())
            {
               var minutes = new string[] {"минут", "минуты"};
               var hours = new string[] { "часа", "часов" };
               var days = new string[] { "дня", "дней" };

               int lastHit = Convert.ToInt32(Math.Round((DateTime.UtcNow - session.First().LastHit).TotalMinutes, 0));
               string unit = string.Empty;
               int ch = int.Parse(lastHit.ToString().Last().ToString());

                if (lastHit < 61)
                {
                    unit = ch > 4 && ch != 0 ? minutes[0] : minutes[1];
                }
                else if (lastHit > 60 && lastHit < 1440)
                {
                    unit = ch > 4 && ch != 0 ? hours[1] : hours[0];
                }
                else
                {
                    var h = (DateTime.UtcNow - session.First().LastHit).Days.ToString();
                    ch = int.Parse(h.Last().ToString());
                    unit = ch > 4 && ch != 0 ? days[1] : days[0];
                }

                status = lastHit < 5 ? "Онлайн" : string.Format("Был на сайте {0} {1} назад", lastHit, unit);
            }
            else
            {
                status = "Оффлайн";
            }

            return status;
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
            dest.DaysOnSite = getDaysOnSite(source.CreationDate);
            dest.Status = getStatus(source);
            dest.Coins = source.Coins;

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
                        dest.LastName = stringValue;
                        break;
                    case Constants.FirstNameCode:
                        dest.FirstName = stringValue;
                        break;
                    case Constants.MiddleNameCode:
                        dest.MiddleName = stringValue;
                        break;
                    case Constants.DateOfBirthCode:
                        dest.BirthDateString = dateTimeValue.ToPandaString();
                        dest.BirthDate = dateTimeValue;
                        break;
                    case Constants.MedicalBookCode:
                        dest.MedicalBook = boolValue;
                        break;
                    case Constants.CarCode:
                        dest.Car = boolValue;
                        break;
                    case Constants.ReadyForWorkCode:
                        dest.ReadyForWork = boolValue;
                        break;
                    case Constants.MobilePhoneCode:
                        dest.MobilePhone = stringValue;
                        break;
                    case Constants.SalaryCode:
                        dest.Salary = dictValue;
                        break;
                    case Constants.CityCode:
                        dest.City = dictValue;
                        break;
                    case Constants.EducationCode:
                        dest.Education = dictValue;
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
                var listWorks2 = new List<string>();

                int count = 0;
                foreach (var desiredWork in desiredWorks)
                {
                    if (count/2 < desiredWorks.Count())
                    {
                        listWorks.Add(desiredWork.Work.Description);
                    }
                    else
                    {
                        listWorks2.Add(desiredWork.Work.Description);
                    }
                    count++;
                }
                dest.DesiredWork1 = listWorks;
                dest.DesiredWork2 = listWorks2;
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
                    var time = string.Format("с {0} по {1}", desiredWorkTime.StartTime.ToPandaTime(),
                        desiredWorkTime.EndTime.ToPandaTime());

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