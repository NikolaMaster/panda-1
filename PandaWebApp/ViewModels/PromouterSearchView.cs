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
        [ValueFrom(Constants.FirstNameCode)]
        public string FirstName { get; set; }
        [ValueFrom(Constants.LastNameCode)]
        public string LastName { get; set; }
        [ValueFrom(Constants.MiddleNameCode)]
        public string MiddleName { get; set; }
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }

        public Checklist Checklist { get; set; }
    }
}