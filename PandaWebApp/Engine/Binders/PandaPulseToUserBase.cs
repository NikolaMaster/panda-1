using PandaDataAccessLayer;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class PandaPulseToUserBase : BaseDataAccessLayerBinder<PandaPulse.Entry, UserBase>
    {
        public const string EmployerImage = "~/Content/img/company.png";
        public const string MaleImage = "~/Content/img/man.png";
        public const string FeemaleImage = "~/Content/img/woman.png";
        public const string UnknownGenderImage = "~/Content/img/car.png";

        public PandaPulseToUserBase(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PandaPulse.Entry source, UserBase dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(UserBase source, PandaPulse.Entry dest)
        {
            dest.User = source;
            if (source is PromouterUser)
            {
                dest.Name = source.LastName + " " + source.FirstName;

                var checklist = (source as PromouterUser).Checklist;
                var gender = DataAccessLayer.GetAttributeValue(checklist.Id, Constants.GenderCode);

                var male = DataAccessLayer.Get<DictValue>("MALE");
                var feemale = DataAccessLayer.Get<DictValue>("FEMALE");
                if (gender == null)
                { 
                    dest.Image = UnknownGenderImage;
                }
                else
                {
                    if (gender.Value == male.Code)
                        dest.Image = MaleImage;
                    else if (gender.Value == feemale.Code)
                        dest.Image = FeemaleImage;
                    else
                        dest.Image = UnknownGenderImage;
                }
                    
            }
            else
            {
                dest.Image = EmployerImage;
                dest.Name = source.LastName;
            }
        }
    }
}