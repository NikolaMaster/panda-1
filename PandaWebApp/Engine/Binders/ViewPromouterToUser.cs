using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
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
            dest.DaysOnSite = Extensions.GetDayOnSiteStatus(source.CreationDate);
            var session = DataAccessLayer.Get<Session>(x => x.User.Id == source.Id).ToList().OrderBy(x=>x.LastHit);
            dest.Status = session.Any() ? Extensions.GetActivityStatus(session.Last().LastHit) : "Оффлайн";
            dest.Coins = source.Coins;
            dest.Phone = new PhoneUnit();
            dest.DesiredWork = new List<PromouterForm.DesiredWorkUnit>();
            dest.AccountConfirmed = source.IsConfirmed;
            //get main album
            var firstOrDefault = source.Albums.FirstOrDefault(x => x.Name == "Основной альбом");
            if (firstOrDefault != null)
                dest.Album = firstOrDefault.Photos.Select(x => x.SourceUrl);

            ValueFromAttributeConverter.ModelFromAttributes(dest, source.MainChecklist.AttrbuteValues, DataAccessLayer);
            foreach (var attrib in source.MainChecklist.AttrbuteValues)
            {
                switch (attrib.Attrib.Code)
                {
                    case Constants.WorkExperienceCode:
                        getWorkExperience(attrib.Value, dest);
                        break;
                    case Constants.DesiredWorkCode:
                        getDesiredWork(attrib.Value, dest);
                        break;
                    case Constants.DesiredWorkTimeCode:
                        getDesiredTimeOfWork(attrib.Value, dest);
                        break;
                    case Constants.MobilePhoneCode:
                        Guid entityListId;
                        if (Guid.TryParse(attrib.Value, out entityListId))
                        {
                            dest.Phone = DataAccessLayer.GetPhone(entityListId);    
                        }
                        break;
                    case Constants.CarCode:
                        dest.Car = attrib.Value;
                        break;
                }
            }
        }

        private void getDesiredWork(string value, Promouter dest)
        {
            dest.DesiredWork = new List<PromouterForm.DesiredWorkUnit>();
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
                .Where(x => x.Value)
                .ToList();


            /*if (string.IsNullOrEmpty(value)) 
                return;
            
                var entityId = Guid.Parse(value);
                var desiredWorks = DataAccessLayer.Get<DesiredWork>(
                x => x.EntityList.Id == entityId).ToList();

                var listWorks = new List<string>();
                var listWorks2 = new List<string>();

                int count = 0;
                var list = desiredWorks as IList<DesiredWork> ?? desiredWorks.ToList();
                foreach (var desiredWork in list)
                {
                    if (count <= list.Count()/2)
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
                dest.DesiredWork2 = listWorks2;*/
            }

        private void getDesiredTimeOfWork(string value, Promouter dest)
        {
            dest.DesiredWorkTime = new List<Promouter.TimeOfWorkUnit>();
            if (string.IsNullOrEmpty(value)) 
                return;

                var entityId = Guid.Parse(value);
                var desiredWorkTimes = DataAccessLayer.Get<DesiredWorkTime>(x => x.EntityList.Id == entityId);
                var sortedDictionary = new SortedDictionary<int, List<string>>();

                foreach (var desiredWorkTime in desiredWorkTimes)
                {
                    var time = string.Format("с {0} по {1}", desiredWorkTime.StartTime.ToPandaTime(),
                        desiredWorkTime.EndTime.ToPandaTime());

                    if (!sortedDictionary.ContainsKey(desiredWorkTime.DayOfWeek))
                    {
                    sortedDictionary.Add(desiredWorkTime.DayOfWeek, new List<string> { time });
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

        private void getWorkExperience(string value, Promouter dest)
        {
            dest.WorkExperience = new List<Promouter.WorkExperienceUnit>();
            if (string.IsNullOrEmpty(value)) 
                return;

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

            var experienceUnits = new List<Promouter.WorkExperienceUnit>();
            foreach (var expirience in allWorkExperience)
            {
                experienceUnits.Add(expirience);
            }

            dest.WorkExperience = experienceUnits;
        }
    }
}
