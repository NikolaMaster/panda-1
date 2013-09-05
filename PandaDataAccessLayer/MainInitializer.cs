using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using PandaDataAccessLayer.DAL;

namespace PandaDataAccessLayer
{
    //DropCreateDatabaseAlways<MainDbContext>//
    public class MainInitializer :CreateDatabaseIfNotExists<MainDbContext>////DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        private MainDbContext mContext;
        private DataAccessLayer mDal;

        protected override void Seed(MainDbContext context)
        {
            mDal = new DataAccessLayer(context);
            mContext = context;

            addDefaultAttribTypes();
            addDefaultChecklistTypes();
            addDefaulAttributes();
            addDefaultImages();
            addDebugEntities();
        }

        private void addDefaultDictAttribTypes()
        {
            #region sex

            var sexGroup = new DictGroup
                {
                    Code = "SEX",
                    Description = "Пол"
                };
            var sexValues = new List<DictValue>() 
                {
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MALE",
                        Description = "Мужской",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "FEMALE",
                        Description = "Женский",
                    }),
                };
            sexGroup = mDal.Create(sexGroup, sexValues).Key;
            mDal.Create<AttribType>(new AttribType
                {
                    DictGroup = sexGroup,
                    Type = typeof(DictGroup).FullName,
                });

            #endregion

            #region cost

            var costGroup = new DictGroup
            {
                Code = "COST",
                Description = "Цена"
            };
            var costs = new int[] { 150, 170, 180, 200, 220, 240, 250, 
                270, 280, 300, 350, 400, 450, 500, 550, 600, 650, 700, 
                800, 900, 1000, 1500, 2000, 3000, 4000, 5000 };
            var costValues = costs.ToList().Select(x => mDal.Create<DictValue>(new DictValue
                    {
                        Code = "COST_" + x.ToString(),
                        Description = x.ToString(),
                    }));

            costGroup = mDal.Create(costGroup, costValues).Key;
            mDal.Create<AttribType>(new AttribType
            {
                DictGroup = costGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            #region education

            var educationGroup = new DictGroup
            {
                Code = "EDUCATION",
                Description = "Образование"
            };
            var educationValues = new List<DictValue>() 
                {
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MIDDLE",
                        Description = "Среднее",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MIDDLE_FULL",
                        Description = "Среднее полное",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "INCOMPLETE_HEIGHT",
                        Description = "Неоконченное высшее",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "HEIGHT",
                        Description = "Высшее",
                    }),
                };
            educationGroup = mDal.Create(educationGroup, educationValues).Key;
            mDal.Create<AttribType>(new AttribType
            {
                DictGroup = educationGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            #region desired work

            var workGroup = new DictGroup
            {
                Code = "JOB",
                Description = "Желаеммая работа"
            };
            var workValues = new List<DictValue>() 
                {
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MERC",
                        Description = "Мерчендайзер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "SUPER",
                        Description = "Супервайзер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "COURIER",
                        Description = "Курьер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "AUDITOR",
                        Description = "Аудитор/Чекер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "BUYER",
                        Description = "Тайный покупатель",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "PROMOUTER",
                        Description = "Промоутер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "AUDITOR",
                        Description = "Аудитор/Чекер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "ANIMATOR",
                        Description = "Аниматор",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "PROMO_MODEL",
                        Description = "Промо-модель",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MASCOT",
                        Description = "Ростовая кукла",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "INTERVIEWER",
                        Description = "Интервьюер",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "MODEL",
                        Description = "Модель",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "WORKER",
                        Description = "Разнорабочий",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "BARMEN",
                        Description = "Бармен",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "WAITER",
                        Description = "Официант",
                    }),
                    mDal.Create<DictValue>(new DictValue
                    {
                        Code = "HOSTESS",
                        Description = "Хостес",
                    }),
                };
            workGroup = mDal.Create(workGroup, workValues).Key;
            mDal.Create<AttribType>(new AttribType
            {
                DictGroup = workGroup,
                Type = typeof(DictGroup).FullName,
            });
            
            #endregion
        }

        private void addDefaultAttribTypes() 
        {
            
            var types = new[] 
            { 
                typeof(string),
                typeof(bool),
                typeof(int),
                typeof(DateTime),
                typeof(EntityList),
            };
            Array.ForEach(types, x => mDal.Create<AttribType>(new AttribType { Type = x.FullName }));
            addDefaultDictAttribTypes();
            mContext.SaveChanges();
        }

        private void addDefaultChecklistTypes()
        {
            var defaultChecklistTypes = new List<ChecklistType> { 
                new ChecklistType {
                    Code = "Promouter"
                },
                new ChecklistType {
                    Code = "Company"
                },
             };
            defaultChecklistTypes.ForEach(x => mContext.ChecklistTypes.Add(x));
            mContext.SaveChanges();
        }

        private void addDefaulAttributes() 
        {
            var attribs = new[] {
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Фамилия",
                    Weight = 1,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Имя"
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Отчество"
                },
                new Attrib 
                {
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "SEX"),
                    Code = "Пол",
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(DateTime)),
                    Code = "Дата рождения",
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = "Медицинская книжка",
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = "Автомобиль",
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = "Готов работать сейчас",
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Мобильный телефон",
                },
                new Attrib 
                {
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "COST"),
                    Code = "Цена работы за час",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Город"
                },
                new Attrib 
                {                    
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "EDUCATION"),
                    Code = "Образование",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = "Опыт работы",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = "Интересующая работа",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = "Желаемое время работы",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Рост"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Телосложение"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Вес"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Тип кожи"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Цвет глаз"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Цвет волос"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Длина волос"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Размер одежды"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Размер груди"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = "Роликовые коньки"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = "Зимние коньки"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "О себе"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Интересы"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Адрес"
                },
                 new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "Наименование компании"
                }
            };
            foreach (var attrib in attribs)
                mDal.Create<Attrib>(attrib);
           mContext.SaveChanges();
        }


        private void addDefaultImages()
        {
            var defaultAvatar = mDal.Create<Photo>(new Photo
            {
                SourceUrl = Constants.DefaultAvatarImage
            });
            mContext.SaveChanges();
        }


        #region DEBUG!!!

        private void addUser1()
        {
            var user = mDal.Create(new PromouterUser()
                {
                    FirstName = "Екатерина",
                    LastName = "Иванова",
                    City = "Сургут",
                    Email = "kate.tmn@gmail.com",
                    Phone = "+7999999999",
                    Password = "123456"
                });

            var sex = mDal.Get<DictValue>(x => x.Code == "FEMALE").First();
            var bithday = new DateTime(1991, 12, 3);
           
            var desiredWorksEntity = mDal.Create<EntityList>(new EntityList() {Id = new Guid()});

            mDal.DbContext.SaveChanges();

            #region works
            var work1 = mDal.Get<DictValue>(x => x.Code == "SUPER").First();
            var work2 = mDal.Get<DictValue>(x => x.Code == "COURIER").First();
            var work3 = mDal.Get<DictValue>(x => x.Code == "WAITER").First();
            var work4 = mDal.Get<DictValue>(x => x.Code == "ANIMATOR").First();
            var work5 = mDal.Get<DictValue>(x => x.Code == "AUDITOR").First();
            var work6 = mDal.Get<DictValue>(x => x.Code == "MODEL").First();
#endregion

            #region DesiredWork

            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work1
                });
            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work2
                });

            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work3
                });

            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work4
                });

            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work5
                });
            mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Work = work6
                });

            #endregion

            #region DesiredWorkTime

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 0
                });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 0
                });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 1
                });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 4
                });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 2
                });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = 1
                });
#endregion

            #region WorkExpirience

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "СургутНИПИ",
                    Hours = 24,
                    WorkName = "Слесарь"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "Нефтемашстрой",
                    Hours = 12,
                    WorkName = "Водитель"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "Газпром",
                    Hours = 12,
                    WorkName = "Дворник"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = desiredWorksEntity,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "УрюпинскНефтьГаз",
                    Hours = 12,
                    WorkName = "Менеджер"
                });

            #endregion

            mDal.DbContext.SaveChanges();

            #region create attributes
            mDal.Create(user, new List<AttribValue>
                {
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Телосложение"),
                            Value = "Стройняшка"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Фамилия"),
                            Value = user.LastName
                        }),
                     mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Отчество"),
                                Value = "Валентиновна"
                         }),

                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Имя"),
                            Value = user.FirstName
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Город"),
                            Value = user.City
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Медицинская книжка"),
                            Value = "true"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Интересующая работа"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),

                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Опыт работы"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Желаемое время работы"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Пол"),
                            Value = sex.Code
                        }),
                     mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Дата рождения"),
                                Value = bithday.ToString()
                         }),

                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("О себе"),
                                Value = "Я такая какая есть"
                         }),

                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Интересы"),
                                Value = "Книги, библиотека, бумага,вышивание"
                         }),
                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Цена работы за час"),
                                Value = mDal.Get<DictValue>("COST_700").Description
                         })
                });

#endregion

            mDal.DbContext.SaveChanges();
            //var entry = mDal.Get<DesiredWork>(x => x.EntityList.Id == desiredWorksEntity.Id);

            #region add album

            var albomFirst = mDal.Create<Album>(new Album()
                {
                    Id = new Guid(),
                    Name = "Это первый альбом",
                    User = user
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = albomFirst,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            var albomSecond = mDal.Create<Album>(new Album()
                {
                    Id = new Guid(),
                    Name = "Это третий альбом",
                    User = user
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = albomSecond,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });


            var mainAlbom = mDal.Get<Album>(x => x.Name == "Основной альбом" && x.User.Id == user.Id).First();

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });

            #endregion

            #region review

            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Rating = 5,
                    Text = "Катя ты не очень",
                    Title = "Страшная",
                    Users = new List<UserBase>() {user}
                });
            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Rating = 2,
                    Text = "Нормальная",
                    Title = "Ниче такая",
                    Users = new List<UserBase>() {user}
                });

            #endregion
        }

        private void addUser2()
        {
            var user = mDal.Create(new PromouterUser()
            {
                FirstName = "Петя",
                LastName = "Сергееев",
                City = "Москва",
                Email = "pet@gmail.com",
                Phone = "+234234",
                Password = "123456"
            });

            var sex = mDal.Get<DictValue>(x => x.Code == "MALE").First();
            var bithday = new DateTime(1980, 7, 3);

            var desiredWorksEntity = mDal.Create<EntityList>(new EntityList() { Id = new Guid() });

            mDal.DbContext.SaveChanges();

            #region works
            var work1 = mDal.Get<DictValue>(x => x.Code == "SUPER").First();
            var work2 = mDal.Get<DictValue>(x => x.Code == "COURIER").First();
            var work3 = mDal.Get<DictValue>(x => x.Code == "WAITER").First();
            var work4 = mDal.Get<DictValue>(x => x.Code == "ANIMATOR").First();
            var work5 = mDal.Get<DictValue>(x => x.Code == "AUDITOR").First();
            var work6 = mDal.Get<DictValue>(x => x.Code == "MODEL").First();
            #endregion

            #region DesiredWork

            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work1
            });
            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work2
            });

            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work3
            });

            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work4
            });

            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work5
            });
            mDal.Create<DesiredWork>(new DesiredWork
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Work = work6
            });

            #endregion

            #region DesiredWorkTime

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 0
            });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 0
            });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 1
            });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 4
            });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 2
            });

            mDal.Create<DesiredWorkTime>(new DesiredWorkTime
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                DayOfWeek = 1
            });
            #endregion

            #region WorkExpirience

            mDal.Create<WorkExpirience>(new WorkExpirience
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Title = "ПарикМэйкер",
                Hours = 24,
                WorkName = "Стилист"
            });

            mDal.Create<WorkExpirience>(new WorkExpirience
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Title = "НефтеМэйкер",
                Hours = 12,
                WorkName = "Парикмахер"
            });

            mDal.Create<WorkExpirience>(new WorkExpirience
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Title = "Газпром",
                Hours = 12,
                WorkName = "Дворник"
            });

            mDal.Create<WorkExpirience>(new WorkExpirience
            {
                Id = new Guid(),
                EntityList = desiredWorksEntity,
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Title = "УрюпНефтьГазМэйкер",
                Hours = 12,
                WorkName = "Менеджер"
            });

            #endregion

            mDal.DbContext.SaveChanges();

            #region create attributes
            mDal.Create(user, new List<AttribValue>
                {
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Телосложение"),
                            Value = "Стройняшка"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Фамилия"),
                            Value = user.LastName
                        }),
                     mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Отчество"),
                                Value = "Анатольевич"
                         }),

                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Имя"),
                            Value = user.FirstName
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Город"),
                            Value = user.City
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Медицинская книжка"),
                            Value = "true"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Интересующая работа"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),

                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Опыт работы"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Желаемое время работы"),
                            Value = desiredWorksEntity.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Пол"),
                            Value = sex.Code
                        }),
                     mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Дата рождения"),
                                Value = bithday.ToString()
                         }),

                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("О себе"),
                                Value = "Я такая какая есть"
                         }),

                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Интересы"),
                                Value = "Книги, библиотека, бумага,вышивание"
                         }),
                         mDal.Create<AttribValue>(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>("Цена работы за час"),
                                Value = mDal.Get<DictValue>("COST_700").Description
                         })
                });

            #endregion

            mDal.DbContext.SaveChanges();
            //var entry = mDal.Get<DesiredWork>(x => x.EntityList.Id == desiredWorksEntity.Id);

            #region add album

            var albomFirst = mDal.Create<Album>(new Album()
            {
                Id = new Guid(),
                Name = "Это первый альбом",
                User = user
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomFirst,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            var albomSecond = mDal.Create<Album>(new Album()
            {
                Id = new Guid(),
                Name = "Это третий альбом",
                User = user
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomSecond,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });


            var mainAlbom = mDal.Get<Album>(x => x.Name == "Основной альбом" && x.User.Id == user.Id).First();

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
            });

            #endregion

            #region review

            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 5,
                Text = "Петя норм пашет",
                Title = "Работает все отлино",
                Users = new List<UserBase>() { user }
            });
            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 2,
                Text = "Зашибись работает",
                Title = "Ниче так",
                Users = new List<UserBase>() { user }
            });

            #endregion
        }

        private void addUser3()
        {
            var user = mDal.Create(new EmployerUser()
            {
                LastName = "ООО 'Рога и копытца'",
                City = "Тюмень",
                Email = "petrov@gmail.com",
                Phone = "+123333",
                Password = "123"
            });
            
            mDal.DbContext.SaveChanges();
            
            mDal.Create(user, new List<AttribValue>
                {
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("О себе"),
                            Value = "Хорошая компания"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Адрес"),
                            Value = "в зареке"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                    {
                        Attrib = mDal.Get<Attrib>("Наименование компании"),
                        Value = "ООО 'Рога и копытца'"
                    })
                });
            
            mDal.DbContext.SaveChanges();
            
            #region add album

            var albomFirst = mDal.Create<Album>(new Album()
            {
                Id = new Guid(),
                Name = "Телочки",
                User = user
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomFirst,
                SourceUrl = "http://t2.gstatic.com/images?q=tbn:ANd9GcQG4W7WLhXnnZdVaQypIqIC1YQIjdnpyF3muXyhaFNAEbUxEGt2qg"
            });


            var albomSecond = mDal.Create<Album>(new Album()
            {
                Id = new Guid(),
                Name = "Это второй альбом",
                User = user
            });

            mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomSecond,
                SourceUrl = "http://t2.gstatic.com/images?q=tbn:ANd9GcQG4W7WLhXnnZdVaQypIqIC1YQIjdnpyF3muXyhaFNAEbUxEGt2qg"
            });

            #endregion

            #region review
            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 5,
                Text = "Не понравиилось",
                Title = "Девочки не очень",
                Users = new List<UserBase>() { user }
            });
            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 2,
                Text = "Хорошая добрая компания",
                Title = "Збс",
                Users = new List<UserBase>() { user }
            });
            #endregion
        }

        public void addDebugEntities() 
        {
            #region add user&attributes
            addUser1();
            addUser2();
            addUser3();
            #endregion
            
            mDal.DbContext.SaveChanges();
        }
        #endregion
    }
}
