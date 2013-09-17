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
    public class EmployerRegisterToEmployerUser : BaseDataAccessLayerBinder<CompanyRegister, EmployerUser>
    {
        public EmployerRegisterToEmployerUser(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(CompanyRegister source, EmployerUser dest)
        {
            dest = DataAccessLayer.Create(new EmployerUser
            {
                Email = source.Email,
                Password = Crypt.GetMD5Hash(source.Password),
            });

            var phoneEntity = DataAccessLayer.Create(new EntityList());

            var phoneNumber = DataAccessLayer.Create(new PhoneNumber
            {
                CountryCode = DataAccessLayer.Get<DictValue>(source.Phone.CountryCode),
                Code = source.Phone.Code,
                Number = source.Phone.Number,
                EntityList = phoneEntity,
            });

            ValueFromAttributeConverter.AttributesFromModel(source, dest.MainChecklist.AttrbuteValues, DataAccessLayer);
        }

        public override void InverseLoad(EmployerUser source, CompanyRegister dest)
        {
            throw new Exception("Only edit bind allowed");
        }
    }
}