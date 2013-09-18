﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class EmployerRegisterToEmployerUser : BaseDataAccessLayerBinder<EmployerRegister, EmployerUser>
    {
        public EmployerRegisterToEmployerUser(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(EmployerRegister source, EmployerUser dest)
        {
            dest.Email = source.Email;
            dest.Password = Password.MakePassword(source.Password, DateTime.UtcNow);

            ValueFromAttributeConverter.AttributesFromModel(source, dest.MainChecklist.AttrbuteValues, DataAccessLayer);

            var phoneEntity = DataAccessLayer.Create(new EntityList());
            var phoneNumber = DataAccessLayer.Create(new PhoneNumber
            {
                CountryCode = DataAccessLayer.Get<DictValue>(source.Phone.CountryCode),
                Code = source.Phone.Code,
                Number = source.Phone.Number,
                EntityList = phoneEntity,
            });

            foreach (var attrib in dest.MainChecklist.AttrbuteValues)
            {
                switch (attrib.Attrib.Code)
                {
                    case Constants.MobilePhoneCode:
                        attrib.Value = phoneEntity.Id.ToString();
                        break;
                }
            }
        }

        public override void InverseLoad(EmployerUser source, EmployerRegister dest)
        {
            throw new Exception("Only edit bind allowed");
        }
    }
}