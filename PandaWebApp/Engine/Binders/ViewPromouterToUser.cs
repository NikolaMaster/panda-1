using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewPromouterToUsers : BaseBinder<Promouter, PromouterUser>
    {
        public DataAccessLayer DataAccessLayer { get; private set; }


        public ViewPromouterToUsers(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }

        public override void Load(Promouter source, PromouterUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(PromouterUser source, Promouter dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;
            dest.Number = source.Number;

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
            
            dest.IntrestingWork1 = new List<string>();
            dest.IntrestingWork2 = new List<string>();

            foreach (var attrib in checklist.AttrbuteValues)
            {
                var dateTimeValue = DateTime.UtcNow;
                var stringValue = attrib.Value;
                var intValue = 0;
                var boolValue = true;

                DateTime.TryParse(stringValue, out dateTimeValue);
                int.TryParse(stringValue, out intValue);
                bool.TryParse(stringValue, out boolValue);

                #region Big switch [TODO by code field]
                switch (attrib.Attrib.Code)
                {
                    case "Дата рождения":
                        dest.BirthDate = dateTimeValue;
                        break;
                    case "Пол":
                        dest.Sex = attrib.Value;
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
                    case "Медицинская книжка":
                        dest.MedicalBook = boolValue;
                        break;
                    case "Автомобиль":
                        dest.Car = boolValue;
                        break;
                    case "Готов работать сейчас":
                        dest.Status = attrib.Value;
                        break;
                    case "Мобильный телефон":
                        dest.MobilePhone = stringValue;
                        break;
                    case "Цена работы за час":
                        dest.CostForHour = intValue;
                        break;
                    case "Город":
                        dest.City = stringValue;
                        break;
                    case "Образование":
                        dest.Education = stringValue;
                        break;
                    case "Опыт работы":
                        getWorkExperience(new Guid(stringValue), dest);
                        break;
                    case "Рост":
                        dest.Height = intValue;
                        break;
                    case "Телосложение":
                        dest.Build = stringValue;
                        break;
                    case "Вес":
                        dest.Weight = intValue;
                        break;
                    case "Тип кожи":
                        dest.SkinType = stringValue;
                        break;
                    case "Цвет глаз":
                        dest.EyeColor = stringValue;
                        break;
                    case "Цвет волос":
                        dest.HairColor = stringValue;
                        break;
                    case "Длина волос":
                        dest.HairLength = stringValue;
                        break;
                    case "Размер одежды":
                        dest.SizeClothes = stringValue;
                        break;
                    case "Размер обуви":
                        dest.SizeShoes = stringValue;
                        break;
                    case "Размер груди":
                        dest.SizeChest = stringValue;
                        break;
                    case "Роликовые коньки":
                        dest.RollerSkates = boolValue;
                        break;
                    case "Зимние коньки":
                        dest.WinterSkates = boolValue;
                        break;
                    case "О себе":
                        dest.About = stringValue;
                        break;
                    case "Интересы":
                        dest.Hobbies = stringValue;
                        break;
                    case "Интересующая работа":
                       getDesiredWork(new Guid(stringValue),dest );
                       break;
                    case "Желаемое время работы":
                       getDesiredTimeOfWork(new Guid(stringValue), dest);
                        break;
                }
                #endregion
            }

            //get main albom
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);
            
        }
        private void getDesiredWork(Guid entityId, Promouter dest)
        {
            var desiredWorks = DataAccessLayer.Get<DesiredWork>(
                x => x.EntityList.Id == entityId);


            return;

            var listWorks = new List<string>();
            foreach (var desiredWork in desiredWorks)
            {
                listWorks.Add(desiredWork.Work.Description);
            }
            dest.IntrestingWork1 = listWorks;
        }

        private void getDesiredTimeOfWork(Guid entityId, Promouter dest)
        {
            var desiredWorkTimes = DataAccessLayer.Get<DesiredWorkTime>(x => x.EntityList.Id == entityId);
            var sortedDictionary = new SortedDictionary<int, List<string>>();

            foreach (var desiredWorkTime in desiredWorkTimes)
            {
                var time = string.Format("с {0} до {1}", desiredWorkTime.StartTime.ToPandaString(),
                                         desiredWorkTime.EndTime.ToPandaString());

                if (!sortedDictionary.ContainsKey(desiredWorkTime.DayOfWeek))
                {
                    sortedDictionary.Add(desiredWorkTime.DayOfWeek, new List<string>() { time });
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
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Понедельник",
                            Time = iter.Value
                        });
                        break;
                    case 1:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Вторник",
                            Time = iter.Value
                        });
                        break;
                    case 2:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Среда",
                            Time = iter.Value
                        });
                        break;
                    case 3:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Четверг",
                            Time = iter.Value
                        });
                        break;
                    case 4:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Пятница",
                            Time = iter.Value
                        });
                        break;
                    case 5:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Суббота",
                            Time = iter.Value
                        });
                        break;
                    case 6:
                        timeOfWorkUnits.Add(new Promouter.TimeOfWorkUnit()
                        {
                            Day = "Воскресенье",
                            Time = iter.Value
                        });
                        break;
                }
            }

            dest.TimeOfWork = timeOfWorkUnits;
        }

        private void getWorkExperience(Guid entityId, Promouter dest)
        {
            var experienceUnits1 = new List<Promouter.WorkExperienceUnit>();
            var experienceUnits2 = new List<Promouter.WorkExperienceUnit>();
            var workExpirience = DataAccessLayer.Get<WorkExpirience>(x => x.EntityList.Id == entityId);
            int countExperience = 0;

            foreach (var expirience in workExpirience)
            {
                if (countExperience >= workExpirience.Count()/2 )
                {
                    experienceUnits1.Add(new Promouter.WorkExperienceUnit()
                    {
                        Title = expirience.Title,
                        StartTime = expirience.Start.ToPandaString(),
                        EndTime = expirience.End.ToPandaString(),
                        Hours = (expirience.Start - expirience.End).Hours
                    });
                }
                else
                {
                    experienceUnits2.Add(new Promouter.WorkExperienceUnit()
                    {
                        Title = expirience.Title,
                        StartTime = expirience.Start.ToPandaString(),
                        EndTime = expirience.End.ToPandaString(),
                        Hours = (expirience.End - expirience.Start).Hours
                    });
                }
                countExperience++;
            }

            dest.WorkExperience1 = experienceUnits1;
            dest.WorkExperience2 = experienceUnits2;

        }
    }
}