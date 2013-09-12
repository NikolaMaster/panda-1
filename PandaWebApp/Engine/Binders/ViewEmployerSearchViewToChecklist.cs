using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewEmployerSearchViewToChecklist : BaseDataAccessLayerBinder<EmployerSearchView, Checklist>
    {
        public ViewEmployerSearchViewToChecklist(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(EmployerSearchView source, Checklist dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(Checklist source, EmployerSearchView dest)
        {
            var cityAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.CityCode);
            var salaryAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.SalaryCode);
            var workAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.WorkCode);
            var companyNameAttribute = DataAccessLayer.GetAttributeValue(source.User.MainChecklist.Id, Constants.EmployerNameCode);
            var genderAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.GenderCode);

            dest.City = cityAttribute.Value != null ? DataAccessLayer.Get<DictValue>(cityAttribute.Value).Description : null;
            dest.Salary = salaryAttribute.Value != null ? DataAccessLayer.Get<DictValue>(salaryAttribute.Value).Description : null;
            dest.Work = workAttribute.Value != null ? DataAccessLayer.Get<DictValue>(workAttribute.Value).Description : null;
            dest.EmployerName = companyNameAttribute != null ? companyNameAttribute.Value : null;
            dest.Gender = genderAttribute.Value != null ? DataAccessLayer.Get<DictValue>(genderAttribute.Value).Description : null;
            dest.Checklist = source;
        }
    }
}