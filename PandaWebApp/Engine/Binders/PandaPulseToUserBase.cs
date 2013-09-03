﻿using PandaDataAccessLayer;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class PandaPulseToUserBase : BaseBinder<PandaPulse.Entry, UserBase>
    {
        public const string CompanyImage = "~/Content/img/company.png";
        public const string MaleImage = "~/Content/img/male.png";
        public const string FeemaleImage = "~/Content/img/feemale.png";
        public const string UnknownGenderImage = "~/Content/img/car.png";

        public DataAccessLayer DataAccessLayer { get; private set; }

        public PandaPulseToUserBase(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }

        public override void Load(PandaPulse.Entry source, UserBase dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(UserBase source, PandaPulse.Entry dest)
        {
            if (source is PromouterUser)
            {
                var sex = (source as PromouterUser).Checklist.AttrbuteValues.FirstOrDefault(x => x.Attrib.Code == "Пол");
                var male = DataAccessLayer.Get<DictValue>("MALE");
                var feemale = DataAccessLayer.Get<DictValue>("MALE");
                if (sex == null)
                { 
                    dest.Image = UnknownGenderImage;
                }
                else
                {
                    if (sex.Value == male.Code)
                        dest.Image = MaleImage;
                    else if (sex.Value == feemale.Code)
                        dest.Image = FeemaleImage;
                    else
                        dest.Image = UnknownGenderImage;
                }
                    
            }
            else
            {
                dest.Image = CompanyImage;
            }
            dest.Name = source.FirstName;
        }
    }
}