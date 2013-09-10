using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;
using PandaDataAccessLayer.DAL;

namespace PandaWebApp.Engine.Editors
{

    public class EmployerEditor : BaseEditor
    {
        public EmployerEditor(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public void Edit(EmployerForm source, EmployerUser dest)
        {
            var checklist = dest.MainChecklist;
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            var mainAlbum = dest.Albums.First();
            if (source.NewPhotos != null)
            {
                foreach (var photo in source.NewPhotos)
                {
                    DataAccessLayer.Create(new Photo
                    {
                        Album = DataAccessLayer.GetById<Album>(mainAlbum.Id),
                        SourceUrl = ImageCreator.SavePhoto(photo)
                    });
                }
            }

            DataAccessLayer.ClearChecklist(checklist);

            foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.EmployerMainChecklistType.Id))
            {
                var attributeValue = new AttribValue
                {
                    AttribId = attribute.Id,
                    ChecklistId = checklist.Id
                };

                #region Big switch [TODO by code field]
                switch (attribute.Code)
                {
                    case Constants.AboutCode:
                        attributeValue.Value = source.About;
                        break;
                    case Constants.EmployerNameCode:
                        attributeValue.Value = source.EmployerName;
                        break;
                    case Constants.AddressCode:
                        attributeValue.Value = source.Address;
                        break;
                    case Constants.MobilePhoneCode:
                        attributeValue.Value = source.MobilePhone;
                        break;
                    case Constants.CityCode:
                        attributeValue.Value = source.City;
                        break;
                }
                #endregion

                checklist.AttrbuteValues.Add(attributeValue);
            }
        }
    }
}