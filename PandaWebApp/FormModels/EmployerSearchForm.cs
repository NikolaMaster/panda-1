using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.FormModels
{
    public class EmployerSearchForm : IPaginators
    {
        public class DesiredWorkDescription 
        {
            public string Code { get; set; }
            public string Title { get; set; }
            public bool Value { get; set; }
            public int Count { get; set; }
        }

        public string Query { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.GenderCode)]
        public string Gender { get; set; }
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }

        public List<DesiredWorkDescription> DesiredWork { get; set; }
        
        public EmployerSearchForm() { }

        public Dictionary<string, int> GetCounts(DataAccessLayer dal)
        {
            //TODO - mode to DAL functions
            return dal.DbContext.Checklists
                .Where(y => y.ChecklistType.Code == Constants.EmployerChecklistTypeCode)
                .Join(
                    dal.DbContext.AttribValues.Where(
                        x => x.Attrib.Code == Constants.WorkCode && !string.IsNullOrEmpty(x.Value)),
                    checkListKey => checkListKey.Id,
                    attributeKey => attributeKey.ChecklistId,
                    (Checklist, Attribute) => new {Checklist, Attribute})
                .GroupBy(x => x.Attribute.Value)
                .ToDictionary(
                    key => key.Key,
                    value => value.Count());
        }

        public EmployerSearchForm(DataAccessLayer dataAccessLayer)
        {
            var counts = GetCounts(dataAccessLayer);
            var desiredWork = dataAccessLayer.Get<DictGroup>(Constants.WorkCode).DictValues
                .Select(x => new DesiredWorkDescription
                {
                    Value = false,
                    Code = x.Code,
                    Title = x.Description,
                    Count = counts.ContainsKey(x.Code) ? counts[x.Code] : 0
                    //Count = dataAccessLayer
                    //    .Get<Checklist>(y => y.ChecklistType.Code == Constants.EmployerChecklistTypeCode)
                    //    .Count(y =>
                    //    {
                    //        var attrib = dataAccessLayer.GetAttributeValue(y.Id, Constants.WorkCode);
                    //        if (attrib != null && !string.IsNullOrEmpty(attrib.Value))
                    //        {
                    //            return attrib.Value == x.Code;
                    //        }
                    //        return false;
                    //    })
                });
            DesiredWork = new List<DesiredWorkDescription>(desiredWork);
        }

        public PagerFormModel Pager { get; set; }
    }
}