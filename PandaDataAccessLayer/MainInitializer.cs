using System.IO;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using PandaDataAccessLayer.DAL;

namespace PandaDataAccessLayer
{//DropCreateDatabaseIfModelChanges<MainDbContext>
    public class MainInitializer : CreateDatabaseIfNotExists<MainDbContext>////DropCreateDatabaseIfModelChanges<MainDbContext>
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
            #region gender

            var genderGroup = new DictGroup
                {
                    Code = "GENDER",
                    Description = Constants.GenderCode
                };
            var genderValues = new List<DictValue>() 
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
            genderGroup = mDal.Create(genderGroup, genderValues).Key;
            mDal.Create<AttribType>(new AttribType
                {
                    DictGroup = genderGroup,
                    Type = typeof(DictGroup).FullName,
                });

            #endregion

            #region cost

            var costGroup = new DictGroup
            {
                Code = "SALARY",
                Description = "Заработная плата за час"
            };
            var costs = new int[] { 150, 170, 180, 200, 220, 240, 250, 
                270, 280, 300, 350, 400, 450, 500, 550, 600, 650, 700, 
                800, 900, 1000, 1500, 2000, 3000, 4000, 5000 };
            var costValues = costs.ToList().Select(x => mDal.Create<DictValue>(new DictValue
                    {
                        Code = "SALARY_" + x.ToString(),
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
                Code = Constants.DesiredWorkCode,
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
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "GENDER"),
                    Code = "GENDER",
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
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "SALARY"),
                    Code = "SALARY",
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = "CITY"
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
                    Code = Constants.DesiredWorkCode
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
                    Code = Constants.CompanyNameCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.VacancyCode
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

            mDal.DbContext.SaveChanges();

            mDal.Create<Session>(new Session()
            {
                LastHit = DateTime.UtcNow,
                User = user
            });

            var sex = mDal.Get<DictValue>("FEMALE");
            var education = mDal.Get<DictValue>("HEIGHT");
            var bithday = new DateTime(1991, 12, 3);
            var entityList = mDal.Create<EntityList>(new EntityList() {Id = new Guid()});
            mDal.DbContext.SaveChanges();
            
            var works = new DictValue[]
                {
                    mDal.Get<DictValue>("SUPER"),
                    mDal.Get<DictValue>("COURIER"),
                    mDal.Get<DictValue>("WAITER"),
                    mDal.Get<DictValue>("ANIMATOR"),
                    mDal.Get<DictValue>("AUDITOR"),
                    mDal.Get<DictValue>("MODEL"),
                };

            for (int i = 0; i < works.Length; i++)
            {
                mDal.Create<DesiredWork>(new DesiredWork
                {
                    Id = new Guid(),
                    EntityList = entityList,
                    Work = works[i]
                });

            }


            for (int i = 0; i < 7; i++)
            {
                mDal.Create<DesiredWorkTime>(new DesiredWorkTime
                {
                    EntityList = entityList,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = i
                });
            }
         
            #region WorkExpirience

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = entityList,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "СургутНИПИ",
                    Hours = 24,
                    WorkName = "Слесарь"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = entityList,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "Нефтемашстрой",
                    Hours = 12,
                    WorkName = "Водитель"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = entityList,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Title = "Газпром",
                    Hours = 12,
                    WorkName = "Дворник"
                });

            mDal.Create<WorkExpirience>(new WorkExpirience
                {
                    Id = new Guid(),
                    EntityList = entityList,
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
                            Attrib = mDal.Get<Attrib>(Constants.CityCode),
                            Value = user.City
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Медицинская книжка"),
                            Value = "true"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.DesiredWorkCode),
                            Value = entityList.Id.ToString()
                        }),

                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Опыт работы"),
                            Value = entityList.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>("Желаемое время работы"),
                            Value = entityList.Id.ToString()
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.GenderCode),
                            Value = sex.Code
                        }),
                     mDal.Create<AttribValue>(new AttribValue
                     {
                        Attrib = mDal.Get<Attrib>("Образование"),
                        Value = education.Code
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
                                Attrib = mDal.Get<Attrib>(Constants.SalaryCode),
                                Value = mDal.Get<DictValue>("SALARY_450").Code
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

            var mainAlbom = mDal.Get<Album>(x => x.Name == "Основной альбом" && x.User.Id == user.Id).First();
            
            /*var avatar = mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = mainAlbom,
                SourceUrl = "http://cs308927.vk.me/v308927964/9a8c/cBfXbTXJdEk.jpg"
            });*/
            
            for (int i = 0; i < 10; i++)
            {
                mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });
               
                mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = albomFirst,
                    SourceUrl = "http://trinixy.ru/pics5/20121108/awesome_40.jpg"
                });
            }

            mDal.DbContext.SaveChanges();

            //mDal.UpdateById<UserBase>(user.Id, x => x.Avatar = avatar);

            #endregion

            #region review

            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Rating = 5,
                    Text = "Работу вополняет на отлично",
                    Title = "Отлично",
                    Users = new List<UserBase>() {user}
                });
            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Rating = 2,
                    Text = "Работу всегда вополняет на отлично",
                    Title = "Отлично",
                    Users = new List<UserBase>() {user}
                });

            #endregion
        }

        private void addUser2()
        {
            var user = mDal.Create(new EmployerUser()
                {
                    LastName = "ООО 'Рога и копытца'",
                    City = "Тюмень",
                    Email = "petrov@gmail.com",
                    Phone = "+9823424",
                    Password = "123"
                });


            mDal.DbContext.SaveChanges();


            mDal.Create<Session>(new Session()
                {
                    LastHit = DateTime.UtcNow,
                    User = user
                });

            var entityList = mDal.Create<EntityList>(new EntityList() {});
            mDal.DbContext.SaveChanges();

            mDal.Create<Vacancy>(new Vacancy
                {
                    EntityList = entityList,
                    Work = mDal.Get<DictValue>("MERC"),
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    CostOfHours = mDal.Get<DictValue>("SALARY_650").Code,
                    WorkDescription = "Добросовестно работать"
                });


            mDal.Create<Vacancy>(new Vacancy
                {
                    EntityList = entityList,
                    Work = mDal.Get<DictValue>("COURIER"),
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.MaxValue,
                    CostOfHours = mDal.Get<DictValue>("SALARY_450").Code,
                    WorkDescription = "Работа по ночам"
                });

            mDal.Create<Vacancy>(new Vacancy
                {
                    EntityList = entityList,
                    Work = mDal.Get<DictValue>("BUYER"),
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.MaxValue,
                    CostOfHours = mDal.Get<DictValue>("SALARY_700").Code,
                    WorkDescription = "ненормированный график работы"
                });
            /*
            mDal.Create<DesiredWork>(new DesiredWork
            {
                EntityList = entityList,
                Work = mDal.Get<DictValue>("SUPER"),
            });
            */

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
                            Value = "Ивана Доброго 153 корпус 5"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Constants.CompanyName,
                            Value = "ООО 'Рога и копытца'"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Constants.Vacancy,
                            Value = entityList.Id.ToString()
                        })
                });

            mDal.DbContext.SaveChanges();

            #region add album

            var albomFirst = mDal.Create<Album>(new Album()
                {
                    Id = new Guid(),
                    Name = "Работа",
                    User = user
                });
            /*
            var avatar = mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomFirst,
                SourceUrl = "http://cs308927.vk.me/v308927964/9a8c/cBfXbTXJdEk.jpg"
            });
            */
            for (int i = 0; i < 10; i++)
            {
                mDal.Create<Photo>(new Photo()
                    {
                        Id = new Guid(),
                        Album = albomFirst,
                        SourceUrl =
                            "http://t2.gstatic.com/images?q=tbn:ANd9GcQG4W7WLhXnnZdVaQypIqIC1YQIjdnpyF3muXyhaFNAEbUxEGt2qg"
                    });
            }


            // mDal.UpdateById<UserBase>(user.Id, x => x.Avatar = avatar);

            #endregion

            #region review


            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.UtcNow,
                    ModifyDate = DateTime.UtcNow,
                    Rating = 5,
                    Text = "Все просто супер",
                    Title = "Отлично",
                    Users = new List<UserBase>() {user}
                });
            mDal.Create<Review>(new Review()
                {
                    CreationDate = DateTime.UtcNow,
                    ModifyDate = DateTime.UtcNow,
                    Rating = 2,
                    Text = "Работа сделана не очень качественно",
                    Title = "Удовлетворительно",
                    Users = new List<UserBase>() {user}
                });

            #endregion

        }

        private void addStaticPages()
        {
            //add static pages
            mDal.Create<StaticPageUnit>(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "About",
                Content = "Первая статичная панда-страница"
            });

            mDal.Create<StaticPageUnit>(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "Dictionary",
                Content = "Вторая статичная панда-страница"
            });

            mDal.Create<StaticPageUnit>(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "FAQ",
                Content = "Третяя статичная панда-страница"
            });

            mDal.Create<StaticPageUnit>(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "Contacts",
                Content = "Четвертая статичная панда-страница"
            });

            mDal.Create<StaticPageUnit>(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "PaidServices",
                Content = "Пятая статичная панда-страница"
            });
        }

        public void addDebugEntities() 
        {
            #region add user&attributes
            addUser1();
            addUser2();
            addStaticPages();

            #endregion
            
            mDal.DbContext.SaveChanges();
        }
        #endregion

    }
}
