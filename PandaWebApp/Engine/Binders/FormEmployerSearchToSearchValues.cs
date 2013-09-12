using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class FormEmployerSearchToSearchValues :  BaseDataAccessLayerBinder<EmployerSearchForm, Dictionary<Attrib, object>>
    {
        public FormEmployerSearchToSearchValues(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(EmployerSearchForm source, Dictionary<Attrib, object> dest)
        {
            var desiredWork = new List<DictValue>();
            desiredWork.AddRange(source.DesiredWork.Where(x => x.Value).Select(x => DataAccessLayer.Get<DictValue>(x.Code)));
            if (desiredWork.Count == 0)
                desiredWork = null;
           
            dest.Add(DataAccessLayer.Constants.Work, desiredWork);
            dest.Add(DataAccessLayer.Constants.City, source.City);
            dest.Add(DataAccessLayer.Constants.Gender, source.Gender);
            dest.Add(DataAccessLayer.Constants.Salary, source.Salary);
        }

        public override void InverseLoad(Dictionary<Attrib, object> source, EmployerSearchForm dest)
        {
            throw new NotImplementedException();
        }
    }
}