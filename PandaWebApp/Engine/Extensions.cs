using System.Globalization;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine
{
    public static class Extensions
    {
        #region Boolean

        public static string ToPandaString(this Boolean b)
        {
            return b ? "Да" : "Нет";
        }

        public static int Int(this Boolean b)
        {
            return b ? 1 : 0;
        }

        #endregion

        #region String

        public static string Shorten(this string src, int newLength)
        {
            return src.Length > newLength 
                ? src.Substring(0, newLength - 3) + "..."
                : src;
        }

        public static string GetString(this byte[] bytes)
        {
            return Encodings.GetString(bytes);
        }

        public static byte[] GetBytes(this string str)
        {
            return Encodings.GetBytes(str);
        }

        public static string ToPandaString(this string str) 
        {
            return str;
        }

        #endregion

        #region Password

        public static string ToPassword(this string passwd)
        {
            return Password.MakePassword(passwd, DateTime.UtcNow);
        }

        #endregion

        #region DateTime

        public static string ToPandaString(this DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy");
        }

        public static string ToPandaString(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToPandaString() : string.Empty;
        }

        public static string ToPandaTime(this DateTime dt)
        {
            return dt.ToString("HH:mm");
        }


        public static string ToPandaTime(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToPandaTime() : string.Empty;
        }

        #endregion

        #region Double

        public static string ToPandaString(this double d)
        {
            return d.ToString("0.00");
        }

        #endregion

        #region Int

        public static string ToPandaString(this int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region DataAccessLayer
        public static IList<SelectListItem> ListItemsFromDict(this DataAccessLayer dataAccessLayer, string groupCode)
        {
            var result = new List<SelectListItem>();
            result.AddRange(dataAccessLayer.Get<DictGroup>(groupCode)
                .DictValues
                .Select(x => new SelectListItem
                {
                    Selected = false,
                    Text = x.Description,
                    Value = x.Code,
                })
                .OrderBy(x => x.Text));
            return result.ToList();
        }
        #endregion

        #region user


        public static PhoneUnit GetPhone(this DataAccessLayer dataAccessLayer, Guid entityListGuid)
        {
            var phone = dataAccessLayer.Get<PhoneNumber>(
                x => x.EntityList.Id == entityListGuid).FirstOrDefault();
            if (phone == null)
                return new PhoneUnit();

            return new PhoneUnit
            {
                CountryCode = phone.CountryCode != null ? phone.CountryCode.Description : null,
                Code = phone.Code,
                Number = phone.Number,
            };
        }

        public static string ControllerNameByUser(this UserBase user)
        {
            var promouterUser = user as PromouterUser;
            var employerUser = user as EmployerUser;
            if (promouterUser != null)
                return "Promouter";
            else if (employerUser != null)
                return "Employer";
            else
                throw new Exception("Incorrect user type");
        }
        #endregion
    }
}