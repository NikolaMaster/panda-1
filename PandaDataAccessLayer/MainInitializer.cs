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

    public partial class MainInitializer : CreateDatabaseIfNotExists<MainDbContext>
    {
        public MainDbContext DbContext { get; protected set; }
        public DataAccessLayer DataAccessLayer { get; protected set; }

        protected override void Seed(MainDbContext context)
        {
            DataAccessLayer = new DataAccessLayer(context);
            DbContext = context;

            addDefaultAttribTypes();
            addDefaultChecklistTypes();
            addDefaulAttributes();
            addAttrib2ChecklistType();

            addTestData();
        }

        private void addDictAttrib(string dictGroupCode, string dictGroupDescription, IEnumerable<object> values)
        {
            var dictGroup = new DictGroup
            {
                Code = dictGroupCode,
                Description = dictGroupDescription
            };
            var dictValues = values.Distinct().Select(t => new DictValue
            {
                Code = t.ToString(),
                Description = t.ToString()
            })
            .ToList();

            dictGroup = DataAccessLayer.Create(dictGroup, dictValues).Key;
            DataAccessLayer.Create(new AttribType
            {
                DictGroup = dictGroup,
                Type = typeof(DictGroup).FullName,
            });
        }

        private void addDefaultDictAttribTypes()
        {
            addDictAttrib(Constants.GenderCode, "Пол", Constants.GenderValues);
            addDictAttrib(Constants.SalaryCode, "Заработная плата за час", Constants.SalaryValues.Select(x => x.ToString(CultureInfo.InvariantCulture)));
            addDictAttrib(Constants.CityCode, "Город", Constants.CityValues);
            addDictAttrib(Constants.WorkCode, "Работа", Constants.WorkValues);
            addDictAttrib(Constants.MobilePhoneCode, "Телефон", Constants.MobilePhoneValues);
            addDictAttrib(Constants.EducationCode, "Образование", Constants.EducationValues);
            addDictAttrib(Constants.EmployerTypeCode, "Тип работодателя", Constants.EmployerTypeValues);
            addDictAttrib(Constants.CompanyTypeCode, "Тип компании", Constants.CompanyTypeValues);
            addDictAttrib(Constants.CompanySubTypeCode, "Подтип компании", Constants.CompanySubTypeValues);

            DataAccessLayer.Create(new DictGroup()
                {
                    Code = Constants.OperationCode,
                    Description = Constants.OperationCode,
                },
                Constants.OperationValues.Select(x => new DictValue
                    {
                        Code = x,
                        Description = x.ToLower(),
                    }));

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
            try
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
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.CarCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(bool)),
                    Code = Constants.ReadyForWorkCode,
                },
                new Attrib 
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(EntityList)),
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
                new Attrib
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.EmployerTypeCode),
                    Code = Constants.EmployerTypeCode 
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.CompanySubTypeCode),
                    Code = Constants.CompanySubTypeCode 
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.CompanyTypeCode),
                    Code = Constants.CompanyTypeCode 
                },
                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.JobTitleCode 
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
                    AttribType = DataAccessLayer.DbContext.AttribTypes.Single(x => x.DictGroup.Code == Constants.WorkCode),
                    Code = Constants.WorkCode
                },
                #endregion

                new Attrib
                {
                    AttribType = DataAccessLayer.GetAttribType(typeof(string)),
                    Code = Constants.EmailCode
                }
            };

            foreach (var attrib in attribs)
                DataAccessLayer.Create(attrib);
            DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
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
                    DataAccessLayer.Constants.CompanyType,
                    DataAccessLayer.Constants.EmployerType,
                    DataAccessLayer.Constants.CompanySubType,
                    DataAccessLayer.Constants.LastName,
                    DataAccessLayer.Constants.FirstName,
                    DataAccessLayer.Constants.JobTitle,
                    DataAccessLayer.Constants.Email
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
                    DataAccessLayer.Constants.Gender,
                    DataAccessLayer.Constants.EmployerName,
                };

            foreach (var attrib2Checklist in employer.Select(x => new Attrib2ChecklistType
                {
                    Attribute = x,
                    ChecklistType = DataAccessLayer.Constants.EmployerChecklistType
                }))
            {
                DataAccessLayer.Create(attrib2Checklist);
            }
            DataAccessLayer.DbContext.SaveChanges();
        }

    }
}
