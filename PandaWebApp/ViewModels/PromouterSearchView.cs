using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.ViewModels
{
    public class PromouterSearchView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Salary { get; set; }
        public string City { get; set; }
        public Checklist Checklist { get; set; }
    }
}