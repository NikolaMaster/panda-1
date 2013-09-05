using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Editors
{
    public class PromouterEditor
    {
        public IEnumerable<Attrib> Attributes { get; private set; }

        public PromouterEditor(IEnumerable<Attrib> attributes)
        {
            Attributes = attributes;
        }

        public void Edit(Promouter source, PromouterUser dest)
        {
            //source.Email = dest.Email;

            var checklist = dest.Checklists.FirstOrDefault();
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            checklist.AttrbuteValues.Clear();

            foreach (var attribute in Attributes)
            {
                var attributeValue = new AttribValue
                {
                    AttribId = attribute.Id,
                    ChecklistId = checklist.Id
                };

                #region Big switch [TODO by code field]
                switch (attribute.Code)
                {
                    case "Фамилия":
                        //TODO
                        break;
                    case "Имя":
                        attributeValue.Value = source.Name;
                        break;
                    case "Отчество":
                        //TODO
                        break;
                    case Constants.GenderCode:
                        //TODO
                        break;
                    case "Дата рождения":
                        attributeValue.Value = source.BirthDate.ToPandaString();
                        break;
                    case "Медицинская книжка":
                        attributeValue.Value = source.MedicalBook.ToPandaString();
                        break;
                    case "Автомобиль":
                        attributeValue.Value = source.Car.ToPandaString();
                        break;
                    case "Готов работать сейчас":
                        //TODO
                        break;
                    case "Мобильный телефон":
                        attributeValue.Value = source.MobilePhone;
                        break;
                    case Constants.SalaryCode:
                        attributeValue.Value = source.CostForHour.ToPandaString();
                        break;
                    case Constants.CityCode:
                        attributeValue.Value = source.City;
                        break;
                    case "Образование":
                        attributeValue.Value = source.Education;
                        break;
                    case "Опыт работы":
                        //TODO
                        break;
                    case "Рост":
                        attributeValue.Value = source.Height.ToPandaString();
                        break;
                    case "Телосложение":
                        attributeValue.Value = source.Build;
                        break;
                    case "Вес":
                        attributeValue.Value = source.Weight.ToPandaString();
                        break;
                    case "Тип кожи":
                        attributeValue.Value = source.SkinType;
                        break;
                    case "Цвет глаз":
                        attributeValue.Value = source.EyeColor;
                        break;
                    case "Цвет волос":
                        attributeValue.Value = source.HairColor;
                        break;
                    case "Длина волос":
                        attributeValue.Value = source.HairLength;
                        break;
                    case "Размер одежды":
                        attributeValue.Value = source.SizeClothes;
                        break;
                    case "Размер обуви":
                        attributeValue.Value = source.SizeShoes;
                        break;
                    case "Размер груди":
                        attributeValue.Value = source.SizeChest;
                        break;
                    case "Роликовые коньки":
                        attributeValue.Value = source.RollerSkates.ToPandaString();
                        break;
                    case "Зимние коньки":
                        attributeValue.Value = source.WinterSkates.ToPandaString();
                        break;
                }
                #endregion

                checklist.AttrbuteValues.Add(attributeValue);
            }
        }
    }
}