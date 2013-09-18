using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class PromouterRegisterToPromouterUser : BaseDataAccessLayerBinder<PromouterRegister, PromouterUser>
    {
        public PromouterRegisterToPromouterUser(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PromouterRegister source, PromouterUser dest)
        {
            dest.Email = source.Email;
            dest.Password = Password.MakePassword(source.Password, DateTime.UtcNow);

            ValueFromAttributeConverter.AttributesFromModel(source, dest.MainChecklist.AttrbuteValues, DataAccessLayer);
        }

        public override void InverseLoad(PromouterUser source, PromouterRegister dest)
        {
            throw new Exception("Only edit bind allowed");
        }
    }
}