﻿using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Engine;

namespace PandaWebApp.FormModels
{
    public class SearchForm
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

        public IEnumerable<SelectListItem> GenderValues { get; set; }
        public IEnumerable<SelectListItem> SalaryValues { get; set; }

        public SearchForm() { }

        public SearchForm(DataAccessLayer dataAccessLayer)
        {
            var desiredWork = dataAccessLayer.Get<DictGroup>(Constants.DesiredWorkCode).DictValues
                .Select(x => new DesiredWorkDescription
                {
                    Value = false,
                    Code = x.Code,
                    Title = x.Description,
                });
            DesiredWork = new List<DesiredWorkDescription>(desiredWork);
            GenderValues = dataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            SalaryValues = dataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? -1 : int.Parse(x.Text));
        }
    }
}