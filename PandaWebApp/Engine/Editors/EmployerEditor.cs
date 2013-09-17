using System.Linq;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
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
            dest.Email = source.Email;
            dest.IsAdmin = source.IsAdmin;

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

            DataAccessLayer.ClearChecklist(dest.MainChecklist);

            foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.EmployerMainChecklistType.Id))
            {
                var attributeValue = new AttribValue
                {
                    Attrib = attribute,
                    AttribId = attribute.Id,
                    ChecklistId = dest.MainChecklist.Id
                };

                switch (attribute.Code)
                {
                    case Constants.MobilePhoneCode:
                        attributeValue.Value = editPhone(source);
                        break;
                }

                dest.MainChecklist.AttrbuteValues.Add(attributeValue);
            }

            ValueFromAttributeConverter.AttributesFromModel(source, dest.MainChecklist.AttrbuteValues, DataAccessLayer);

            //vacancies
            foreach (var vacancy in source.Vacancies.OrderBy(x => x.CreationDate))
            {
                var checklist = DataAccessLayer.GetById<Checklist>(vacancy.Id);

                DataAccessLayer.ClearChecklist(checklist);

                foreach (var attribute in DataAccessLayer.GetAttributes(DataAccessLayer.Constants.EmployerChecklistType.Id))
                {
                    var attributeValue = new AttribValue
                    {
                        Attrib = attribute,
                        AttribId = attribute.Id,
                        ChecklistId = checklist.Id
                    };

                    checklist.AttrbuteValues.Add(attributeValue);
                }

                ValueFromAttributeConverter.AttributesFromModel(vacancy, checklist.AttrbuteValues, DataAccessLayer);

            }
        }

        private string editPhone(EmployerForm source)
        {
            var entityList = DataAccessLayer.Create(new EntityList());
            if (source.Phone != null)
            {
                DataAccessLayer.Create(new PhoneNumber
                {
                    EntityList = entityList,
                    CountryCode = DataAccessLayer.Get<DictValue>(source.Phone.CountryCode),
                    Code = source.Phone.Code,
                    Number = source.Phone.Number,
                });
            }
            return entityList.Id.ToString();
        }
    }
}