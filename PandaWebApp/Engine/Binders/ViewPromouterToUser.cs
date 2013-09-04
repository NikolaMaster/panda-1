using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class ViewPromouterToUsers : BaseBinder<Promouter, PromouterUser>
    {
        public override void Load(Promouter source, PromouterUser dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(PromouterUser source, Promouter dest)
        {
            dest.Email = source.Email;

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
                    case "Фамилия":
                        //TODO
                        break;
                    case "Имя":
                        dest.Name = attrib.Value;
                        break;
                    case "Отчество":
                        //TODO
                        break;
                    case "Пол":
                        //TODO
                        break;
                    case "Дата рождения":
                        dest.BirthDate = dateTimeValue;
                        break;
                    case "Медицинская книжка":
                        dest.MedicalBook = boolValue;
                        break;
                    case "Автомобиль":
                        dest.Car = boolValue;
                        break;
                    case "Готов работать сейчас":
                        //TODO
                        break;
                    case "Мобильный телефон":
                        dest.MobilePhone = stringValue;
                        break;
                    case "Цена работы за час":
                        dest.CostForHour = intValue;
                        break;
                    case "CITY":
                        dest.City = stringValue;
                        break;
                    case "Образование":
                        dest.Education = stringValue;
                        break;
                    case "Опыт работы":
                        //TODO
                        break;
                    case "Рост":
                        dest.Height = intValue;
                        break;
                    case "Телосложение":
                        dest.Build = stringValue;
                        break;
                    case "Вес":
                        dest.Weight = intValue;
                        break;
                    case "Тип кожи":
                        dest.SkinType = stringValue;
                        break;
                    case "Цвет глаз":
                        dest.EyeColor = stringValue;
                        break;
                    case "Цвет волос":
                        dest.HairColor = stringValue;
                        break;
                    case "Длина волос":
                        dest.HairLength = stringValue;
                        break;
                    case "Размер одежды":
                        dest.SizeClothes = stringValue;
                        break;
                    case "Размер обуви":
                        dest.SizeShoes = stringValue;
                        break;
                    case "Размер груди":
                        dest.SizeChest = stringValue;
                        break;
                    case "Роликовые коньки":
                        dest.RollerSkates = boolValue;
                        break;
                    case "Зимние коньки":
                        dest.WinterSkates = boolValue;
                        break;
                }
                #endregion
            }

            //fake
            dest.Album = source.Albums.FirstOrDefault().Photos.Select(x => x.SourceUrl);
            dest.IntrestingWork1 = new List<string>();
            dest.IntrestingWork2 = new List<string>();
        }
    }
}