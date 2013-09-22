using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.ViewModels
{
    public class Vacancy
    {
        [ValueFrom(Constants.EmployerNameCode)]
        public string EmployerName { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }
        [ValueFrom(Constants.WorkCode)]
        public string Work { get; set; }
        [ValueFrom(Constants.GenderCode)]
        public string Gender { get; set; }
        [ValueFrom(Constants.StartWorkCode)]
        public DateTime? Start { get; set; }
        [ValueFrom(Constants.EndWorkCode)]
        public DateTime? End { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }

        public int Days { get; set; }
        public int DaysOnSite { get; set; }
        public string AvatarUrl { get; set; }
        public Checklist Checklist { get; set; }
    }

}