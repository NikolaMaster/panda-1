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
            var desiredWorkAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.DesiredWorkCode);
            var companyNameAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.CompanyNameCode);

            DesiredWork desiredWork = null;
            if (desiredWorkAttribute != null)
            {
                var entListId = new Guid(desiredWorkAttribute.Value);
                desiredWork = DataAccessLayer.Get<DesiredWork>(x => x.EntityList.Id == entListId).FirstOrDefault();
            }

            dest.City = cityAttribute != null ? cityAttribute.Value : null;
            dest.Salary = salaryAttribute != null ? salaryAttribute.Value : null;
            dest.Work = desiredWork != null ? desiredWork.Work.Description : null;
            dest.CompanyName = companyNameAttribute != null ? companyNameAttribute.Value : null;
        }
    }
}