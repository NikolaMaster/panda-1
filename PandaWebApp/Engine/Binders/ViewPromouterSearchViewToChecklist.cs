using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;


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
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(Checklist source, PromouterSearchView dest)
        {
            ValueFromAttributeConverter.ModelFromAttributes(dest, source.AttrbuteValues, DataAccessLayer);
            dest.Checklist = source;
        }
    }
}