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
            throw new NotImplementedException();
        }

        public override void InverseLoad(Dictionary<Attrib, object> source, SearchForm dest)
        {
            throw new NotImplementedException();
        }
    }
}