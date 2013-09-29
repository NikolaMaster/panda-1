using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.FormModels
{
    public class PromouterSearchForm : IPaginators
    {
        public string Query { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
        public string Education { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public PagerFormModel Pager { get; set; }
    }
}