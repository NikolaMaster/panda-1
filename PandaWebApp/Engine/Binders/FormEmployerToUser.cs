using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormEmployerToUser : BaseDataAccessLayerBinder<EmployerForm, EmployerUser>
    {
        public FormEmployerToUser(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {  
        }


        public override void Load(EmployerForm source, EmployerUser dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(EmployerUser source, EmployerForm dest)
        {
            dest.UserId = source.Id;
            dest.Email = source.Email;
            dest.Photo = source.Avatar.SourceUrl;
            
            if (source.MainChecklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            var counter = 0;

        }
    }
}