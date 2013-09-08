using System.Globalization;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public class Constants
    {
        public const string PromouterChecklistTypeCode = "Promouter";
        public const string EmployerChecklistTypeCode = "Employer";
        public const string DefaultAvatarImage = "motorcycle.jpeg";

        public const string DesiredWorkCode = "DESIRED_WORK";
        public const string WorkExperienceCode = "WORK_EXPERIENCE";
        public const string CityCode = "CITY";
        public const string GenderCode = "GENDER";
        public const string SalaryCode = "SALARY";
        public const string EmployerNameCode = "EMPLOYER_NAME";
        public const string VacancyCode = "VACANCY";
        public const string EducationCode = "EDUCATION";
        public const string DateOfBirthCode = "DATE_OF_BIRTH";
        public const string MedicalBookCode = "MEDICAL_BOOK";
        public const string CarCode = "CAR";
        public const string MobilePhoneCode = "MOBILE_PHONE";
        public const string HeightCode = "HEIGHT";
        public const string WeightCode = "WEIGHT";
        public const string BuildCode = "BUILD";
        public const string EyeColorCode = "EYE_COLOR";
        public const string HairLengthCode = "HAIR_LENGTH";
        public const string SkinTypeCode = "SKIN_TYPE";
        public const string HairColorCode = "HAIR_COLOR";
        public const string SizeClothesCode = "SIZE_CLOTHES";
        public const string SizeShoesCode = "SIZE_SHOES";
        public const string SizeChestCode = "SIZE_CHEST";
        public const string RollerSkatesCode = "ROLLER_SKATES";
        public const string WinterSkatesCode = "WINTER_SKATES";
        public const string HobbiesCode = "HOBBIES";
        public const string AboutCode = "ABOUT";
        public const string AddressCode = "ADDRESS";
        public const string DesiredWorkTimeCode = "DESIRED_WORK_TIME";


        public static readonly string[] EducationValues =
        {
            "Среднее",
            "Среднее полное",
            "Неоконченное высшее",
            "Высшее"
        };
        public static readonly string[] EducationValuesCode =
        {
            "MIDDLE",
            "MIDDLE_FULL",
            "INCOMPLETE_HEIGHT",
            "HEIGHT"
        };


        public static readonly int[] SalaryValues =
        {
            150, 170, 180, 200, 220, 240, 250,
            270, 280, 300, 350, 400, 450, 500, 550, 600, 650, 700,
            800, 900, 1000, 1500, 2000, 3000, 4000, 5000
        };
        public static readonly string[] SalaryValuesCode = SalaryValues
            .Select(x => SalaryCode + "_" + x.ToString(CultureInfo.InvariantCulture))
            .ToArray();

        public DataAccessLayer DataAccessLayer { get;private set; }

        private Constants() { }

        internal Constants(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public Photo DefaultAvatar
        {
            get { return DataAccessLayer.DbContext.Set<Photo>().Single(x => x.SourceUrl == DefaultAvatarImage); }
        }

        public ChecklistType PromouterChecklistType 
        {
            get { return DataAccessLayer.Get<ChecklistType>(PromouterChecklistTypeCode); }
        }

        public ChecklistType EmployerChecklistType
        {
            get { return DataAccessLayer.Get<ChecklistType>(EmployerChecklistTypeCode); }
        }

        
        public Attrib DesiredWork 
        {
            get { return DataAccessLayer.Get<Attrib>(DesiredWorkCode); }
        }

        public Attrib City 
        {
            get { return DataAccessLayer.Get<Attrib>(CityCode); }
        }

        public Attrib Gender 
        {
            get { return DataAccessLayer.Get<Attrib>(GenderCode); }
        }

        public Attrib Salary 
        {
            get { return DataAccessLayer.Get<Attrib>(SalaryCode); }
        }

        public Attrib EmployerName 
        {
            get { return DataAccessLayer.Get<Attrib>(EmployerNameCode); }
        }

        public Attrib Vacancy
        {
            get { return DataAccessLayer.Get<Attrib>(VacancyCode); }
        }

        public Attrib Education 
        {
            get { return DataAccessLayer.Get<Attrib>(EducationCode); }
        }

        public Attrib WorkExperience 
        {
            get { return DataAccessLayer.Get<Attrib>(WorkExperienceCode); }
        }

        public Attrib DateOfBirth 
        {
            get { return DataAccessLayer.Get<Attrib>(DateOfBirthCode); }
        }
        
        public Attrib MedicalBook 
        {
            get { return DataAccessLayer.Get<Attrib>(MedicalBookCode); }
        }

        public Attrib Car
        {
            get { return DataAccessLayer.Get<Attrib>(CarCode); }
        }

        public Attrib MobilePhone
        {
            get { return DataAccessLayer.Get<Attrib>(MobilePhoneCode); }
        }

        public Attrib Height
        {
            get { return DataAccessLayer.Get<Attrib>(HeightCode); }
        }

        public Attrib Weight
        {
            get { return DataAccessLayer.Get<Attrib>(WeightCode); }
        }

        public Attrib Build
        {
            get { return DataAccessLayer.Get<Attrib>(BuildCode); }
        }    

        public Attrib EyeColor
        {
            get { return DataAccessLayer.Get<Attrib>(EyeColorCode); }
        }

        public Attrib SkinType
        {
            get { return DataAccessLayer.Get<Attrib>(SkinTypeCode); }
        }

        public Attrib HairColor
        {
            get { return DataAccessLayer.Get<Attrib>(HairColorCode); }
        }

        public Attrib HairLength
        {
            get { return DataAccessLayer.Get<Attrib>(HairLengthCode); }
        }

        public Attrib SizeClothes
        {
            get { return DataAccessLayer.Get<Attrib>(SizeClothesCode); }
        }

        public Attrib SizeShoes
        {
            get { return DataAccessLayer.Get<Attrib>(SizeShoesCode); }
        }

        public Attrib SizeChest
        {
            get { return DataAccessLayer.Get<Attrib>(SizeChestCode); }
        }

        public Attrib RollerSkates
        {
            get { return DataAccessLayer.Get<Attrib>(RollerSkatesCode); }
        }

        public Attrib WinterSkates
        {
            get { return DataAccessLayer.Get<Attrib>(WinterSkatesCode); }
        }

        public Attrib Hobbies
        {
            get { return DataAccessLayer.Get<Attrib>(HobbiesCode); }
        }

        public Attrib About
        {
            get { return DataAccessLayer.Get<Attrib>(AboutCode); }
        }

        public Attrib Address
        {
            get { return DataAccessLayer.Get<Attrib>(AddressCode); }
        }
       
        public Attrib DesiredWorkTime
        {
            get { return DataAccessLayer.Get<Attrib>(DesiredWorkTimeCode); }
        }
    }
}
