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
            dest.Name = DataAccessLayer.GetUserName(source) ?? string.Empty;
             
            var promouterUser = source as PromouterUser;
            var employerUser = source as EmployerUser;
            if (promouterUser == null && employerUser == null)
            {
                throw  new Exception("Incorrect user type");
            }

            if (promouterUser != null)
            {
                var gender = DataAccessLayer.GetAttributeValue(promouterUser.MainChecklist.Id, Constants.GenderCode);
                if (gender == null)
                { 
                    dest.Image = UnknownGenderImage;
                }
                else
                {
                    if (gender.Value == Constants.MaleCode)
                        dest.Image = MaleImage;
                    else if (gender.Value == Constants.FemaleCode)
                        dest.Image = FeemaleImage;
                    else
                        dest.Image = UnknownGenderImage;
                }
            }
            else
            {
                dest.Image = EmployerImage;
            }
        }
    }
}