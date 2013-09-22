using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.ViewModels
{
    public class PromouterSearchView
    {
        
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.GenderCode)]
        public string Gender { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }

        public string FullName { get; set; }
        public int Days { get; set; }
        public int DaysOnSite { get; set; }
        public string AvatarUrl { get; set; }
        public Checklist Checklist { get; set; }
    }
}