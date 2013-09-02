using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class ViewEmployerToUser : BaseBinder<Employer, EmployerUser>
    {
        public override void Load(Employer source, EmployerUser dest)
        {
           
        }

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
           
        }
    }
}