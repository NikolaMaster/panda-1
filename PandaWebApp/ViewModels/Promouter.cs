using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.Engine;

namespace PandaWebApp.ViewModels
{
    public class Promouter
    {
        public struct TimeOfWorkUnit
        {
            public string Day;
            public bool IWantIt;
            public List<string> Time;
        }

        public struct WorkExperienceUnit
        {
            public string Title;
            public string StartTime;
            public string EndTime;
            public int Hours;
        }

        public Guid UserId { get; set; }

        public string Icon { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Education { get; set; }
        public string Build { get; set; }
        public string SkinType { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string HairLength { get; set; }
        public string SizeClothes { get; set; }
        public string SizeShoes { get; set; }
        public string SizeChest { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }

        public int Weight { get; set; }
        public int Number { get; set; }
        public int DaysOnSite { get; set; }
        public int Height { get; set; }
        public int FullYears 
        {
            get
            {
                if (BirthDate == null)
                {
#if RELEASE
                    return 0;
#endif
#if DEBUG
                    throw new ArgumentNullException("BirthDate");
#endif
                }
                var date = DateTime.UtcNow;
                var lastYear = date.Year - 1;
                var currentBirthDate = new DateTime(
                        date.Year,
                        BirthDate.Month,
                        BirthDate.Day
                    );
                return lastYear - BirthDate.Year + (currentBirthDate <= date).Int();
            }
        }

        public bool AccountConfirmed { get; set; }
        public bool MedicalBook { get; set; }
        public bool Car { get; set; }
        public bool RollerSkates { get; set; }
        public bool WinterSkates { get; set; }

        public DateTime BirthDate { get; set; }

        public double CostForHour { get; set; }

        public IEnumerable<string> Album { get; set; }
        public IEnumerable<string> IntrestingWork1 { get; set; }
        public IEnumerable<string> IntrestingWork2 { get; set; }
        public IEnumerable<TimeOfWorkUnit> TimeOfWork { get; set; }
        public IEnumerable<Feedback> Reviews { get; set; }
        public IEnumerable<WorkExperienceUnit> WorkExperience1 { get; set; }
        public IEnumerable<WorkExperienceUnit> WorkExperience2 { get; set; }

    }
}