using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.FormModels
{
    public class PromouterSearchForm
    {
        public string Query { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
    }
}