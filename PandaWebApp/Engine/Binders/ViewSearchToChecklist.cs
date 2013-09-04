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
            dest.City = DataAccessLayer.GetAttributeValue(source.Id, "CITY").Value;
        }
    }
}