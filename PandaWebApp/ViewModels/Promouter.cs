using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaWebApp.Engine;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;

namespace PandaWebApp.ViewModels
{
    public class Promouter
    {
        public class TimeOfWorkUnit
        {
            public string Day { get; set; }
            public bool IWantIt { get; set; }
            public List<string> Time { get; set; }
        }

        public class WorkExperienceUnit
        {
            public string Title { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string WorkName { get; set; }
            public int Hours { get; set; }
        }

        [ValueFrom(Constants.FirstNameCode)]
        public string FirstName { get; set; }
        [ValueFrom(Constants.LastNameCode)]
        public string LastName { get; set; }
        [ValueFrom(Constants.MiddleNameCode)]
        public string MiddleName { get; set; }
        [ValueFrom(Constants.GenderCode)]
        public string Gender { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.EducationCode)]
        public string Education { get; set; }
        [ValueFrom(Constants.BuildCode)]
        public string Build { get; set; }
        [ValueFrom(Constants.SkinTypeCode)]
        public string SkinType { get; set; }
        [ValueFrom(Constants.EyeColorCode)]
        public string EyeColor { get; set; }
        [ValueFrom(Constants.HairColorCode)]
        public string HairColor { get; set; }
        [ValueFrom(Constants.HairLengthCode)]
        public string HairLength { get; set; }
        [ValueFrom(Constants.SizeClothesCode)]
        public string SizeClothes { get; set; }
        [ValueFrom(Constants.SizeShoesCode)]
        public string SizeShoes { get; set; }
        [ValueFrom(Constants.SizeChestCode)]
        public string SizeChest { get; set; }
        [ValueFrom(Constants.HobbiesCode)]
        public string Hobbies { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }
        [ValueFrom(Constants.DateOfBirthCode)]
        public string BirthDateString { get; set; }
        [ValueFrom(Constants.CarCode)]
        public string Car { get; set; }
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }
        [ValueFrom(Constants.WeightCode)]
        public int Weight { get; set; }
        [ValueFrom(Constants.HeightCode)]
        public int Height { get; set; }
        [ValueFrom(Constants.MedicalBookCode)]
        public bool MedicalBook { get; set; }
        [ValueFrom(Constants.RollerSkatesCode)]
        public bool RollerSkates { get; set; }
        [ValueFrom(Constants.WinterSkatesCode)]
        public bool WinterSkates { get; set; }
        [ValueFrom(Constants.ReadyForWorkCode)]
        public bool ReadyForWork { get; set; }
        [ValueFrom(Constants.DateOfBirthCode)]
        public DateTime? BirthDate { get; set; }

        public Guid UserId { get; set; }

        public int Coins { get; set; }
        public int Number { get; set; }
        public bool AccountConfirmed { get; set; }
        public string DaysOnSite { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }

        public int FullYears 
        {
            get
            {
                if (!BirthDate.HasValue)
                {
                    return 0;
                }
                var date = DateTime.UtcNow;
                var lastYear = date.Year - 1;
                var currentBirthDate = new DateTime(
                        date.Year,
                        BirthDate.Value.Month,
                        BirthDate.Value.Day
                    );
                return lastYear - BirthDate.Value.Year + (currentBirthDate <= date).Int();
            }
        }

        public PhoneUnit Phone { get; set; }
        public IEnumerable<string> Album { get; set; }
        //public IEnumerable<string> DesiredWork1 { get; set; }
        //public IEnumerable<string> DesiredWork2 { get; set; }
        public IList<PromouterForm.DesiredWorkUnit> DesiredWork { get; set; }
        public IEnumerable<TimeOfWorkUnit> DesiredWorkTime { get; set; }
        public IEnumerable<Feedback> Reviews { get; set; }
        public IEnumerable<WorkExperienceUnit> WorkExperience { get; set; }
    }
}