using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    /*    public DictValue Gender { get; set; }
        public DictValue Cost { get; set; }
        */
        public List<DesiredWorkDescription> DesiredWork { get; set; }

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
        }
    }
}