using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewPromouterSearchViewToChecklist : BaseDataAccessLayerBinder<PromouterSearchView, Checklist>
    {
        public ViewPromouterSearchViewToChecklist(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PromouterSearchView source, Checklist dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(Checklist source, PromouterSearchView dest)
        {
            var cityAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.CityCode);
            var salaryAttribute = DataAccessLayer.GetAttributeValue(source.Id, Constants.SalaryCode);
            var firstNameAttribute = DataAccessLayer.GetAttributeValue(source.User.MainChecklist.Id, Constants.FirstNameCode);
            var lastNameAttribute = DataAccessLayer.GetAttributeValue(source.User.MainChecklist.Id, Constants.LastNameCode);
            var middleNameAttribute = DataAccessLayer.GetAttributeValue(source.User.MainChecklist.Id, Constants.MiddleNameCode);

            dest.City = cityAttribute.Value != null ? DataAccessLayer.Get<DictValue>(cityAttribute.Value).Description : null;
            dest.Salary = salaryAttribute.Value != null ? DataAccessLayer.Get<DictValue>(salaryAttribute.Value).Description : null;
            dest.FirstName = firstNameAttribute != null ? firstNameAttribute.Value : null;
            dest.LastName = lastNameAttribute != null ? lastNameAttribute.Value : null;
            dest.MiddleName = middleNameAttribute != null ? middleNameAttribute.Value : null;
            dest.Checklist = source;
        }
    }
}