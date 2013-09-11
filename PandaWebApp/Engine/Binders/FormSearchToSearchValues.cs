using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class FormSearchToSearchValues :  BaseDataAccessLayerBinder<SearchForm, Dictionary<Attrib, object>>
    {
        public FormSearchToSearchValues(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(SearchForm source, Dictionary<Attrib, object> dest)
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

        public override void InverseLoad(Dictionary<Attrib, object> source, SearchForm dest)
        {
            throw new NotImplementedException();
        }
    }
}