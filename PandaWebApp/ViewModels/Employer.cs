using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.Engine;

namespace PandaWebApp.ViewModels
{
    public class Employer
    {
        public struct VacancyUnit
        {
            public DateTime? StartTime;
            public DateTime? EndTime;
            public string JobTitle;
            public string Salary;
            public string DaysOnSite;
            public string FullDescription;
            public string City;
        }

        public Guid UserId { get; set; }
        public string Icon { get; set; }
        public string EmployerName { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public int DaysOnSite { get; set; }
        public bool AccountConfirmed { get; set; }
        public IEnumerable<string> Album { get; set; }
        public IEnumerable<Feedback> Reviews { get; set; }
        public IEnumerable<VacancyUnit> Vacancies { get; set; }
    }
}