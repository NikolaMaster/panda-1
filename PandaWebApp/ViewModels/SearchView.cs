﻿using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class SearchView
    {
        public string EmployerName { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public string Work { get; set; }
        public Checklist Checklist { get; set; }
    }
}