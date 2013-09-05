using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class ViewEmployerToUser : BaseBinder<Employer, EmployerUser>
    {
        public DataAccessLayer DataAccessLayer { get; private set; }

        public ViewEmployerToUser(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }

        public override void Load(Employer source, EmployerUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(EmployerUser source, Employer dest)
        {
            dest.UserId = source.Id;
            dest.Email  = source.Email;
           // dest.Photo  = source.Avatar.SourceUrl;
            dest.Number = source.Number;
            dest.City = source.City;
            //get main album
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);

            var checklist = source.Checklists.FirstOrDefault();
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            foreach (var attrib in checklist.AttrbuteValues)
            {
                var dateTimeValue = DateTime.UtcNow;
                var stringValue = attrib.Value;
                var intValue = 0;
                var boolValue = true;

                DateTime.TryParse(stringValue, out dateTimeValue);
                int.TryParse(stringValue, out intValue);
                bool.TryParse(stringValue, out boolValue);

                #region Big switch [TODO by code field]
                switch (attrib.Attrib.Code)
                {
                    case "Мобильный телефон":
                        dest.MobilePhone = stringValue;
                        break;
                    case "О себе":
                        dest.About = stringValue;
                        break;
                    case "Наименование компании":
                        dest.Name = stringValue;
                        break;
                    case "Адрес":
                        dest.Address = stringValue;
                        break;
                }
                #endregion
            }



        }


    }
}