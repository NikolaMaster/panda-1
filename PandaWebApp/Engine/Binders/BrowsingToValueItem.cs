using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.Engine.Binders
{
    public class BrowsingToValueItem : BaseDataAccessLayerBinder<Browsing, FormModels.Browsing.ValueItem>
    {
        public BrowsingToValueItem(DataAccessLayer dal)
            : base(dal)
        {

        }

        public override void Load(Browsing source, FormModels.Browsing.ValueItem dest)
        {
            dest.UserController = source.What.ControllerNameByUser();
            dest.UserName = DataAccessLayer.GetPulseUserName(source.What);
            dest.When = source.When;
        }

        public override void InverseLoad(FormModels.Browsing.ValueItem source, Browsing dest)
        {
            throw new NotImplementedException();
        }
    }
}