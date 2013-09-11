using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewSearchToChecklist : BaseDataAccessLayerBinder<SearchView, Checklist>
    {
        public ViewSearchToChecklist(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(SearchView source, Checklist dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(Checklist source, SearchView dest)
        {
            
            var cityAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.CityCode);
            var salaryAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.SalaryCode);
            var workAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.WorkCode);
            var companyNameAttribute = DataAccessLayer.GetAttributeValue(source.User.MainChecklist.Id, Constants.EmployerNameCode);

            dest.City = cityAttribute != null ? cityAttribute.Value : null;
            dest.Salary = salaryAttribute.Value != null ? DataAccessLayer.Get<DictValue>(salaryAttribute.Value).Description : null;
            dest.Work = workAttribute.Value != null ? DataAccessLayer.Get<DictValue>(workAttribute.Value).Description : null;
            dest.EmployerName = companyNameAttribute != null ? companyNameAttribute.Value : null;
            dest.Checklist = source;
        }
    }
}