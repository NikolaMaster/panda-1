using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.ViewModels
{
    public class EmployerSearchView
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

        public Checklist Checklist { get; set; }
    }

}