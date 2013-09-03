using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class RegisterEmployerToUsers : BaseBinder<Register.Employer, UserBase>
    {
        public override void Load(Register.Employer source, UserBase dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            dest.Password = source.Password;
            //TODO password
        }

        public override void InverseLoad(UserBase source, Register.Employer dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            //TODO password
        }
    }
}