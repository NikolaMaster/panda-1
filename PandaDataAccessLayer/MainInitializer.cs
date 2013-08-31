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
    public class MainInitializer  : DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        internal const string DefaultAvatarImage = "motorcycle.jpeg";

        protected override void Seed(MainDbContext context)
        {
            addDefaultAttribTypes(context);
            addDefaultChecklistTypes(context);
            addDefaulAttributes(context);
            addDefaultImages(context);
        }

        private void addDefaultDictAttribTypes(MainDbContext context)
        {
            var dal = new DAL<MainDbContext>(context);

            #region sex

            var sexGroup = new DictGroup
                {
                    Code = "SEX",
                    Description = "Пол"
                };
            var sexValues = new List<DictValue>() 
                {
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MALE",
                        Description = "Мужской",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "FEMALE",
                        Description = "Женский",
                    }),
                };
            sexGroup = dal.CreateDictGroup(sexGroup, sexValues).Key;
            dal.Create<AttribType>(new AttribType
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
            var costValues = costs.ToList().Select(x => dal.Create<DictValue>(new DictValue
                    {
                        Code = "COST_" + x.ToString(),
                        Description = x.ToString(),
                    }));

            costGroup = dal.CreateDictGroup(costGroup, costValues).Key;
            dal.Create<AttribType>(new AttribType
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
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MIDDLE",
                        Description = "Среднее",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MIDDLE_FULL",
                        Description = "Среднее полное",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "INCOMPLETE_HEIGHT",
                        Description = "Неоконченное высшее",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "HEIGHT",
                        Description = "Высшее",
                    }),
                };
            educationGroup = dal.CreateDictGroup(educationGroup, educationValues).Key;
            dal.Create<AttribType>(new AttribType
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
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MERC",
                        Description = "Мерчендайзер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "SUPER",
                        Description = "Супервайзер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "COURIER",
                        Description = "Курьер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "AUDITOR",
                        Description = "Аудитор/Чекер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "BUYER",
                        Description = "Тайный покупатель",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "PROMOUTER",
                        Description = "Промоутер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "AUDITOR",
                        Description = "Аудитор/Чекер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "ANIMATOR",
                        Description = "Аниматор",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "PROMO_MODEL",
                        Description = "Промо-модель",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MASCOT",
                        Description = "Ростовая кукла",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "INTERVIEWER",
                        Description = "Интервьюер",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "MODEL",
                        Description = "Модель",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "WORKER",
                        Description = "Разнорабочий",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "BARMEN",
                        Description = "Бармен",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "WAITER",
                        Description = "Официант",
                    }),
                    dal.Create<DictValue>(new DictValue
                    {
                        Code = "HOSTESS",
                        Description = "Хостес",
                    }),
                };
            workGroup = dal.CreateDictGroup(workGroup, workValues).Key;
            dal.Create<AttribType>(new AttribType
            {
                DictGroup = workGroup,
                Type = typeof(DictGroup).FullName,
            });
            
            #endregion
        }

        private void addDefaultAttribTypes(MainDbContext context) 
        {
            var dal = new DAL<MainDbContext>(context);
            
            var types = new[] 
            { 
                typeof(string),
                typeof(bool),
                typeof(int),
                typeof(DateTime),
                typeof(EntityList),
            };
            Array.ForEach(types, x => dal.Create<AttribType>(new AttribType { Type = x.FullName }));
            addDefaultDictAttribTypes(context);
            context.SaveChanges();
        }

        private void addDefaultChecklistTypes(MainDbContext context)
        {
            var defaultChecklistTypes = new List<ChecklistType> { 
                new ChecklistType {
                    Code = "Promouter"
                },
                new ChecklistType {
                    Code = "Company"
                },
             };
            defaultChecklistTypes.ForEach(x => context.ChecklistTypes.Add(x));
            context.SaveChanges();
        }

        private void addDefaulAttributes(MainDbContext context) 
        {
            var dal = new DAL<MainDbContext>(context);
            var attribs = new[] {
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Фамилия",
                    Weight = 1,
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Имя"
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Отчество"
                },
                new Attrib 
                {
                    AttribType = dal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "SEX"),
                    Name = "Пол",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(DateTime)),
                    Name = "Дата рождения",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Медицинская книжка",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Автомобиль",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Автомобиль",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Готов работать сейчас",
                },
                new Attrib 
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Мобильный телефон",
                },
                new Attrib 
                {
                    AttribType = dal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "COST"),
                    Name = "Цена работы за час",
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Город"
                },
                new Attrib 
                {                    
                    AttribType = dal.DbContext.AttribTypes.Single(x => x.DictGroup.Code == "EDUCATION"),
                    Name = "Образование",
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(EntityList)),
                    Name = "Опыт работы",
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(EntityList)),
                    Name = "Интересующая работа",
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(EntityList)),
                    Name = "Желаемое время работы",
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Рост"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Телосложение"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Вес"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Тип кожи"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Цвет глаз"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Цвет волос"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Длина волос"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Размер одежды"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Размер обуви"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Размер груди"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(int)),
                    Name = "Размер обуви"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Роликовые коньки"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(bool)),
                    Name = "Зимние коньки"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "О себе"
                },
                new Attrib
                {
                    AttribType = dal.GetAttribType(typeof(string)),
                    Name = "Интересы"
                },
            };
            foreach (var attrib in attribs)
                dal.Create<Attrib>(attrib);
            context.SaveChanges();
        }


        private void addDefaultImages(MainDbContext context)
        {
            var dal = new DAL<MainDbContext>(context);
            var defaultAvatar = dal.Create<Photo>(new Photo
            {
                SourceUrl = DefaultAvatarImage
            });
            context.SaveChanges();
        }
    }
}
