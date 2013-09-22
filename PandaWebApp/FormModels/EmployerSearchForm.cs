using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Engine;

namespace PandaWebApp.FormModels
{
    public class EmployerSearchForm : IPaginators
    {
        public class DesiredWorkDescription 
        {
            public string Code { get; set; }
            public string Title { get; set; }
            public bool Value { get; set; }
        }

        public string Query { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }

        public List<DesiredWorkDescription> DesiredWork { get; set; }
        
        public EmployerSearchForm() { }

        public EmployerSearchForm(DataAccessLayer dataAccessLayer)
        {
            var desiredWork = dataAccessLayer.Get<DictGroup>(Constants.WorkCode).DictValues
                .Select(x => new DesiredWorkDescription
                {
                    Value = false,
                    Code = x.Code,
                    Title = x.Description,
                });
            DesiredWork = new List<DesiredWorkDescription>(desiredWork);
        }

        public PagerFormModel Pager { get; set; }
    }
}