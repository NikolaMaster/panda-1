using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.ViewModels
{
    public class Employer
    {
        [ValueFrom(Constants.EmployerNameCode)]
        public string EmployerName { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }
        [ValueFrom(Constants.AddressCode)]
        public string Address { get; set; }


        public Guid UserId { get; set; }
        public string Icon { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

        public int Number { get; set; }
        public string DaysOnSite { get; set; }
        public int Coins { get; set; }
        public bool AccountConfirmed { get; set; }
        public bool IsAdmin { get; set; }

        public PhoneUnit Phone { get; set; }
        public IEnumerable<string> Album { get; set; }
        public IEnumerable<Feedback> Reviews { get; set; }
        public IEnumerable<Vacancy> Vacancies { get; set; }
    }
}