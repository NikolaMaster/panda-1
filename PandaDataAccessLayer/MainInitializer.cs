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

    public partial class MainInitializer : DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        public MainDbContext DbContext { get; protected set; }
        public DataAccessLayer DataAccessLayer { get; protected set; }

        protected override void Seed(MainDbContext context)
        {
            DataAccessLayer = new DataAccessLayer(context);
            DbContext = context;
//            mContext.Configuration.LazyLoadingEnabled = false;

            addDefaultAttribTypes();
            addDefaultChecklistTypes();
            addDefaulAttributes();
            addAttrib2ChecklistType();
            addDefaultImages();

            addTestData();
            //    addDebugEntities();
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

            genderGroup = DataAccessLayer.Create(genderGroup, genderValues).Key;
            DataAccessLayer.Create(new AttribType
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

            costGroup = DataAccessLayer.Create(costGroup, costValues).Key;
            DataAccessLayer.Create(new AttribType
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

            educationGroup = DataAccessLayer.Create(educationGroup, educationValues).Key;
            DataAccessLayer.Create(new AttribType
            {
                DictGroup = educationGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            #region city

            var cityGroup = new DictGroup
            {
                Code = Constants.CityCode,
                Description = "Город"
            };
            var cityValues = Constants.CityValues.Select(x => new DictValue
            {
                Code = x,
                Description = x
            })
            .ToList();

            educationGroup = DataAccessLayer.Create(cityGroup, cityValues).Key;
            DataAccessLayer.Create(new AttribType
            {
                DictGroup = cityGroup,
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
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "MERC",
                        Description = "Мерчендайзер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "SUPER",
                        Description = "Супервайзер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "COURIER",
                        Description = "Курьер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "AUDITOR",
                        Description = "Аудитор/Чекер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "BUYER",
                        Description = "Тайный покупатель",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "PROMOUTER",
                        Description = "Промоутер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "ANIMATOR",
                        Description = "Аниматор",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "PROMO_MODEL",
                        Description = "Промо-модель",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "MASCOT",
                        Description = "Ростовая кукла",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "INTERVIEWER",
                        Description = "Интервьюер",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "MODEL",
                        Description = "Модель",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "WORKER",
                        Description = "Разнорабочий",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "BARMEN",
                        Description = "Бармен",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "WAITER",
                        Description = "Официант",
                    }),
                    DataAccessLayer.Create(new DictValue
                    {
                        Code = "HOSTESS",
                        Description = "Хостес",
                    }),
                };
            workGroup = DataAccessLayer.Create(workGroup, workValues).Key;
            DataAccessLayer.Create(new AttribType
            {
                DictGroup = workGroup,
                Type = typeof(DictGroup).FullName,
            });

            #endregion

            DbContext.SaveChanges();
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
            Array.ForEach(types, x => DataAccessLayer.Create(new AttribType { Type = x.FullName }));
            addDefaultDictAttribTypes();
            DbContext.SaveChanges();
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
                new ChecklistType {
                    Code = Constants.EmployerMainChecklistTypeCode
                },
             };
            defaultChecklistTypes.ForEach(x => DbContext.ChecklistTypes.Add(x));
            DbContext.SaveChanges();
        }

        private void addDefaulAttributes() 
        {
            var attribs = new[] {
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.LastNameCode,
                    Weight = 1,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.FirstNameCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.MiddleNameCode
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.GenderCode),
                    Code = Constants.GenderCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(DateTime)),
                    Code = Constants.DateOfBirthCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.MedicalBookCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.CarCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.ReadyForWorkCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.MobilePhoneCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.SalaryCode),
                    Code = Constants.SalaryCode,
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.CityCode),
                    Code = Constants.CityCode
                },
                new Attrib 
                {                    
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.EducationCode),
                    Code = Constants.EducationCode,
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(EntityList)),
                    Code = Constants.WorkExperienceCode,
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(EntityList)),
                    Code = Constants.DesiredWorkCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(EntityList)),
                    Code = Constants.DesiredWorkTimeCode,
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(int)),
                    Code = Constants.HeightCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.BuildCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(int)),
                    Code = Constants.WeightCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.SkinTypeCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.EyeColorCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.HairColorCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.HairLengthCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(int)),
                    Code = Constants.SizeClothesCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(int)),
                    Code = Constants.SizeShoesCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(int)),
                    Code = Constants.SizeChestCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.RollerSkatesCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.WinterSkatesCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.AboutCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.HobbiesCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.AddressCode
                },
                 new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.EmployerNameCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.VacancyCode
                },

                #region added attr for vacancy
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(DateTime)),
                    Code = Constants.StartWorkCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(DateTime)),
                    Code = Constants.EndWorkCode
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.DesiredWorkCode),
                    Code = Constants.WorkCode
                }
                #endregion
            };
            foreach (var attrib in attribs)
                DataAccessLayer.Create(attrib);
           DbContext.SaveChanges();
        }


        private void addDefaultImages()
        {
            var defaultAvatar = DataAccessLayer.Create<Photo>(new Photo
            {
                SourceUrl = Constants.DefaultAvatarImage
            });
            DbContext.SaveChanges();
        }


        private void addAttrib2ChecklistType()
        {
            #region Promouter

            var promouter = new[]
                {
                    DataAccessLayer.Constants.Gender,
                    DataAccessLayer.Constants.LastName,
                    DataAccessLayer.Constants.FirstName,
                    DataAccessLayer.Constants.MiddleName,
                    DataAccessLayer.Constants.DateOfBirth,
                    DataAccessLayer.Constants.MedicalBook,
                    DataAccessLayer.Constants.Car,
                    DataAccessLayer.Constants.ReadyForWork,
                    DataAccessLayer.Constants.MobilePhone,
                    DataAccessLayer.Constants.Salary,
                    DataAccessLayer.Constants.City,
                    DataAccessLayer.Constants.Education,
                    DataAccessLayer.Constants.Height,
                    DataAccessLayer.Constants.Build,
                    DataAccessLayer.Constants.Weight,
                    DataAccessLayer.Constants.SkinType,
                    DataAccessLayer.Constants.EyeColor,
                    DataAccessLayer.Constants.HairColor,
                    DataAccessLayer.Constants.HairLength,
                    DataAccessLayer.Constants.SizeClothes,
                    DataAccessLayer.Constants.SizeShoes,
                    DataAccessLayer.Constants.SizeChest,
                    DataAccessLayer.Constants.RollerSkates,
                    DataAccessLayer.Constants.WinterSkates,
                    DataAccessLayer.Constants.Hobbies,
                    DataAccessLayer.Constants.About,
                    DataAccessLayer.Constants.ReadyForWork,
                    DataAccessLayer.Constants.WorkExperience,
                    DataAccessLayer.Constants.DesiredWork,
                    DataAccessLayer.Constants.DesiredWorkTime,
                };

            foreach (var attrib2Checklist in promouter.Select(x => new Attrib2ChecklistType
                {
                    Attribute = x,
                    ChecklistType = DataAccessLayer.Constants.PromouterChecklistType
                }))
            {
                DataAccessLayer.Create(attrib2Checklist);
            }

            #endregion

            #region Employer main checklist

            var employerMain = new[]
                {
                    DataAccessLayer.Constants.About,
                    DataAccessLayer.Constants.EmployerName,
                    DataAccessLayer.Constants.Address,
                    DataAccessLayer.Constants.MobilePhone,
                    DataAccessLayer.Constants.City,
                };

            foreach (var attrib2Checklist in employerMain.Select(x => new Attrib2ChecklistType
                {
                    Attribute = x,
                    ChecklistType = DataAccessLayer.Constants.EmployerMainChecklistType
                }))
            {
                DataAccessLayer.Create(attrib2Checklist);
            }

            #endregion


            var employer = new[]
                {
                    DataAccessLayer.Constants.Salary,
                    DataAccessLayer.Constants.Work,
                    DataAccessLayer.Constants.StartWork,
                    DataAccessLayer.Constants.EndWork,
                    DataAccessLayer.Constants.About,
                    DataAccessLayer.Constants.City,
                    DataAccessLayer.Constants.Gender
                };

            foreach (var attrib2Checklist in employer.Select(x => new Attrib2ChecklistType
                {
                    Attribute = x,
                    ChecklistType = DataAccessLayer.Constants.EmployerChecklistType
                }))
            {
                DataAccessLayer.Create(attrib2Checklist);
            }

        }

    }
}
