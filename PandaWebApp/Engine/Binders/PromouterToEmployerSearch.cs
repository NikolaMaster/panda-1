using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class PromouterToEmployerSearch : BaseDataAccessLayerBinder<PromouterUser, EmployerSearchForm>
    {
        public PromouterToEmployerSearch(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PromouterUser source, EmployerSearchForm dest)
        {
            ValueFromAttributeConverter.ModelFromAttributes(dest, source.MainChecklist.AttrbuteValues, DataAccessLayer);
        }

        public override void InverseLoad(EmployerSearchForm source, PromouterUser dest)
        {
            throw new NotImplementedException();
        }
    }
}