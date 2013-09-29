using System;
using System.Collections.Generic;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormPromouterSearchToSearchValues : BaseDataAccessLayerBinder<PromouterSearchForm, Dictionary<Attrib, object>>
    {
        public FormPromouterSearchToSearchValues(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PromouterSearchForm source, Dictionary<Attrib, object> dest)
        {
            dest.Add(DataAccessLayer.Constants.City, source.City);
            dest.Add(DataAccessLayer.Constants.Gender, source.Gender);
            dest.Add(DataAccessLayer.Constants.Salary, source.Salary);
            dest.Add(DataAccessLayer.Constants.Education, source.Education);
            dest.Add(DataAccessLayer.Constants.DateOfBirth, new Tuple<int, int>(source.MinAge, source.MaxAge));
        }

        public override void InverseLoad(Dictionary<Attrib, object> source, PromouterSearchForm dest)
        {
            throw new Exception("Only edit bind allowed");
        }
    }
}