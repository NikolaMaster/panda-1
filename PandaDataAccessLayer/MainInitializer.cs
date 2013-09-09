using System.IO;
using System.Globalization;
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
            addAttrib2ChecklistType();
            addDefaultImages();
            addDebugEntities();
        }

        private void addDefaultDictAttribTypes()
        {
            #region gender

            var genderGroup = new DictGroup
            {
                Code = Constants.GenderCode,
                Description = "Пол"
            }; 
            var genderValues = Constants.GenderValues.Select((t, i) => new DictValue
            {
                Code = Constants.GenderValuesCode[i],
                Description = t.ToString(CultureInfo.InvariantCulture)
            })
            .ToList();

            genderGroup = mDal.Create(genderGroup, genderValues).Key;
            mDal.Create(new AttribType
                {
                    DictGroup = genderGroup,
                    Type = typeof(DictGroup).FullName,
                });

            #endregion

            #region cost

            var costGroup = new DictGroup
            {
                Code = Constants.SalaryCode,
                Description = "Заработная плата за час"
            };
            var costValues = Constants.SalaryValues.Select((t, i) => new DictValue
                    {
                Code = Constants.SalaryValuesCode[i], 
                Description = t.ToString(CultureInfo.InvariantCulture)
            })
            .ToList();

            costGroup = mDal.Create(costGroup, costValues).Key;
            mDal.Create(new AttribType
            {
                DictGroup = costGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            #region education

            var educationGroup = new DictGroup
            {
                Code = Constants.EducationCode,
                Description = "Образование"
            };
            var educationValues = Constants.EducationValues.Select((t, i) => new DictValue
                {
                Code = Constants.EducationValuesCode[i],
                Description = t
            })
            .ToList();

            educationGroup = mDal.Create(educationGroup, educationValues).Key;
            mDal.Create(new AttribType
            {
                DictGroup = educationGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            #region desired work

            var workGroup = new DictGroup
            {
                Code = Constants.DesiredWorkCode,
                Description = "Желаемая работа"
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

            mContext.SaveChanges();
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
                    Code = Constants.PromouterChecklistTypeCode
                },
                new ChecklistType {
                    Code = Constants.EmployerChecklistTypeCode
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
                    Code = Constants.LastNameCode,
                    Weight = 1,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.FirstNameCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.MiddleNameCode
                },
                new Attrib 
                {
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.GenderCode),
                    Code = Constants.GenderCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(DateTime)),
                    Code = Constants.DateOfBirthCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = Constants.MedicalBookCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = Constants.CarCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = Constants.ReadyForWorkCode,
                },
                new Attrib 
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.MobilePhoneCode,
                },
                new Attrib 
                {
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.SalaryCode),
                    Code = Constants.SalaryCode,
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.CityCode
                },
                new Attrib 
                {                    
                    AttribType = mDal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.EducationCode),
                    Code = Constants.EducationCode,
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = Constants.WorkExperienceCode,
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = Constants.DesiredWorkCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(EntityList)),
                    Code = Constants.DesiredWorkTimeCode,
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = Constants.HeightCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.BuildCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = Constants.WeightCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.SkinTypeCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.EyeColorCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.HairColorCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.HairLengthCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = Constants.SizeClothesCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = Constants.SizeShoesCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = Constants.SizeChestCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = Constants.RollerSkatesCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(bool)),
                    Code = Constants.WinterSkatesCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.AboutCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.HobbiesCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.AddressCode
                },
                 new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.EmployerNameCode
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(string)),
                    Code = Constants.VacancyCode
                }
                
            };
            foreach (var attrib in attribs)
                mDal.Create(attrib);
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


        private void addAttrib2ChecklistType() 
        {
            #region Promouter
            var promouter = new Attrib[]{
                mDal.Constants.DateOfBirth,
                mDal.Constants.MedicalBook,
                mDal.Constants.Car,
                mDal.Constants.MobilePhone,
                mDal.Constants.Salary,
                mDal.Constants.City,
                mDal.Constants.Education,
                mDal.Constants.DesiredWork,
                mDal.Constants.Gender,
                mDal.Constants.Height,
                mDal.Constants.Build,
                mDal.Constants.EyeColor,
                mDal.Constants.SkinType,
                mDal.Constants.HairColor,
                mDal.Constants.HairLength,
                mDal.Constants.SizeClothes,
                mDal.Constants.SizeShoes,
                mDal.Constants.SizeChest,
                mDal.Constants.Hobbies,
                mDal.Constants.About,
                mDal.Constants.DesiredWorkTime

            };

            foreach (var attrib2checklist in promouter.Select(x => new Attrib2ChecklistType 
                {
                    Attribute = x, ChecklistType = mDal.Constants.PromouterChecklistType 
                }))
            {
                mDal.Create<Attrib2ChecklistType>(attrib2checklist);
            }
            

            #endregion
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
            var bithday = new DateTime(1991, 12, 3);
           
            var desiredWorkEntity = mDal.Create(new EntityList() { });
            var desiredWorkTimeEntity = mDal.Create(new EntityList() { }); 
            var workExperienceEntity = mDal.Create(new EntityList() { });
            mDal.DbContext.SaveChanges();

            #region works
            var work1 = mDal.Get<DictValue>("SUPER");
            var work2 = mDal.Get<DictValue>("COURIER");
            var work3 = mDal.Get<DictValue>("WAITER");
            var work4 = mDal.Get<DictValue>("ANIMATOR");
            var work5 = mDal.Get<DictValue>("AUDITOR");
            var work6 = mDal.Get<DictValue>("MODEL");
            #endregion

            var works = new []
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
                mDal.Create(new DesiredWork
                {
                    EntityList = desiredWorkEntity,
                    Work = works[i]
                });

            }


            for (int i = 0; i < 7; i++)
            {
                mDal.Create(new DesiredWorkTime
                {
                    EntityList = desiredWorkTimeEntity,
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow,
                    DayOfWeek = i
                });
            }

            #region Session

            mDal.Create(new Session
                {
                    LastHit = DateTime.UtcNow,
                    User = user
                });

            mDal.DbContext.SaveChanges();
            #endregion

            #region create attributes
            mDal.Create(user, new List<AttribValue>
                {
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.BuildCode),
                            Value = "Стройняшка"
                        }),
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.LastNameCode),
                            Value = user.LastName
                        }),
                     mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.MiddleNameCode),
                                Value = "Валентиновна"
                         }),

                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.FirstNameCode),
                            Value = user.FirstName
                        }),
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.CityCode),
                            Value = user.City
                        }),
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.MedicalBookCode),
                            Value = true.ToString()
                        }),

                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.WorkExperienceCode),
                            Value = workExperienceEntity.Id.ToString()
                        }),
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.DesiredWorkCode),
                            Value = desiredWorkEntity.Id.ToString()
                        }),
                    mDal.Create(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.GenderCode),
                            Value = Constants.FemaleCode
                        }),
                     mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.DateOfBirthCode),
                                Value = bithday.ToString()
                         }),

                         mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.AboutCode),
                                Value = "Я такая какая есть"
                         }),

                         mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.HobbiesCode),
                                Value = "Книги, библиотека, бумага,вышивание"
                         }),
                         mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.SalaryCode),
                                Value = mDal.Get<DictValue>("SALARY_150").Code
                         }),
                         mDal.Create(new AttribValue
                        {
                                Attrib = mDal.Get<Attrib>(Constants.DesiredWorkTimeCode),
                                Value = desiredWorkTimeEntity.Id.ToString()
                         }),
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

            var avatar = mDal.Create<Photo>(new Photo()
                {
                    Id = new Guid(),
                    Album = mainAlbom,
                    SourceUrl = "~/Content/img/girl.jpeg"
            });
            mDal.Refresh(avatar);

            mDal.UpdateById<UserBase>(user.Id, x => x.Avatar = avatar);


            for (int i = 0; i < 10; i++)
            {
                mDal.Create<Photo>(new Photo()
                    {
                        Id = new Guid(),
                        Album = mainAlbom,
                        SourceUrl = "~/Content/img/girl.jpeg"
                    });
            }

            mDal.DbContext.SaveChanges();


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
            
            
            var vacanciesEntity = mDal.Create(new EntityList() { });
            
            mDal.DbContext.SaveChanges();

            vacanciesEntity = mDal.Refresh(vacanciesEntity);

            mDal.Create<Session>(new Session()
            {
                    LastHit = DateTime.UtcNow,
                    User = user
            });

            mDal.DbContext.SaveChanges();

            mDal.Create<Vacancy>(new Vacancy
            {
                EntityList = vacanciesEntity,
                Work = mDal.Get<DictValue>("MERC"),
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow,
                WorkDescription = "Добросовестно работать",
                CostOfHours = mDal.Get<DictValue>("SALARY_450")
            });


            mDal.Create<Vacancy>(new Vacancy
            {
                EntityList = vacanciesEntity,
                Work = mDal.Get<DictValue>("COURIER"),
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.MaxValue,
                WorkDescription = "Работа по ночам",
                CostOfHours = mDal.Get<DictValue>("SALARY_700")
            });
         
            mDal.Create<Vacancy>(new Vacancy
            {
                EntityList = vacanciesEntity,
                Work = mDal.Get<DictValue>("BUYER"),
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.MaxValue,
                WorkDescription = "ненормированный график работы",
                CostOfHours = mDal.Get<DictValue>("SALARY_200")
            });
            
            
            mDal.Create(user, new List<AttribValue>
                {
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.AboutCode),
                            Value = "Хорошая компания"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                        {
                            Attrib = mDal.Get<Attrib>(Constants.AddressCode),
                            Value = "Ивана Доброго 153 корпус 5"
                        }),
                    mDal.Create<AttribValue>(new AttribValue
                    {
                        Attrib = mDal.Constants.EmployerName,
                        Value = "ООО 'Рога и копытца'"
                    }),
                    mDal.Create<AttribValue>(new AttribValue
                    {
                        Attrib = mDal.Constants.Vacancy,
                        Value = vacanciesEntity.Id.ToString()
                    })
                });
            
            mDal.DbContext.SaveChanges();
            
            #region add album

            var albomFirst = mDal.Create<Album>(new Album()
            {
                    Name = "Работа",
                    User = user
            });

            for (int i = 0; i < 10; i++)
            {
                mDal.Create<Photo>(new Photo()
                    {
                        Album = albomFirst,
                        SourceUrl =
                            "~/Content/img/company_avatar.jpg"
                    });
            }


            var avatar = mDal.Create<Photo>(new Photo()
            {
                Id = new Guid(),
                Album = albomFirst,
                SourceUrl = "~/Content/img/company_avatar.jpg"
            });
            mDal.Refresh(avatar);
            mDal.UpdateById<UserBase>(user.Id, x => x.Avatar = avatar);

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
            mDal.Create(new StaticPageUnit()
            {
                Id = new Guid(),
                Code = "About",
                Content = "Первая статичная панда-страница"
            });

            mDal.Create(new StaticPageUnit()
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
