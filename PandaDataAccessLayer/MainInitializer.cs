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
    public class MainInitializer  : CreateDatabaseIfNotExists<MainDbContext>//DropCreateDatabaseIfModelChanges<MainDbContext>
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
                    Code = "Размер обуви"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Размер груди"
                },
                new Attrib
                {
                    AttribType = mDal.GetAttribType(typeof(int)),
                    Code = "Размер обуви"
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
        public void addDebugEntities() 
        {
            var user = mDal.Create(new PromouterUser()
            {
                FirstName = "Dmitry",
                LastName = "Kostyanetsky",
                City = "Tyumen",
                Email = "redrick.tmn@gmail.com",
                Phone = "+79123833395",
                Password = "123",

            });
            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 5,
                Text = "Sonme text blah blah blah <b>BOLD</b>",
                Title = "Title",
                Users = new List<UserBase>() { user }
            });
            mDal.Create<Review>(new Review()
            {
                CreationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Rating = 2,
                Text = "Sasdasdasdasd",
                Title = "Title #2",
                Users = new List<UserBase>() { user }
            });
            mDal.DbContext.SaveChanges();
        }
        #endregion
    }
}
