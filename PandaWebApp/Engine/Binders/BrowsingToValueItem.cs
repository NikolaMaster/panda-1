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
            dest.UserController = source.Who.ControllerNameByUser();
            dest.UserName = DataAccessLayer.GetPulseUserName(source.Who);
            dest.When = source.When;
            dest.UserId = source.Who.Id;
        }

        public override void InverseLoad(FormModels.Browsing.ValueItem source, Browsing dest)
        {
            throw new NotImplementedException();
        }
    }
}