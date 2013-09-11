using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private void editMainParam(EmployerForm source, EmployerUser dest)
        {
            dest.Email = source.Email;
            dest.IsAdmin = source.IsAdmin;
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

        private void editChecklists(EmployerForm source, EmployerUser dest)
        {
            foreach (var vacancy in source.Vacancies)
            {
                var checklist = DataAccessLayer.GetById<Checklist>(vacancy.Id);
                if (checklist == null)
                {
#if DEBUG
                    throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
                }

                DataAccessLayer.ClearChecklist(checklist);

                foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.EmployerChecklistType.Id))
                {
                    var attributeValue = new AttribValue
                    {
                        AttribId = attribute.Id,
                        ChecklistId = checklist.Id
                    };
                    switch (attribute.Code)
                    {
                        case Constants.SalaryCode:
                            attributeValue.Value = vacancy.Salary;
                            break;
                        case Constants.WorkCode:
                            attributeValue.Value = vacancy.Work;
                            break;
                        case Constants.AboutCode:
                            attributeValue.Value = vacancy.FullDescription;
                            break;
                        case Constants.StartWorkCode:
                            attributeValue.Value = vacancy.StartTime.ToPandaString();
                            break;
                        case Constants.EndWorkCode:
                            attributeValue.Value = vacancy.EndTime.ToPandaString();
                            break;
                        case Constants.CityCode:
                            attributeValue.Value = vacancy.City;
                            break;
                    }

                    checklist.AttrbuteValues.Add(attributeValue);
                }
             
            }
        }

        public void Edit(EmployerForm source, EmployerUser dest)
        {
            editMainParam(source, dest);
            editChecklists(source, dest);
        }
    }
}