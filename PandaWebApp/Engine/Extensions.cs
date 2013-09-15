using System.Text.RegularExpressions;
using System.Web.Mvc.Ajax;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Helpers;

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
            return i.ToString();
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

        #region status

        private static int getWordEnd(int number)
        {
            if (Regex.Match(number.ToString(), "1\\d$").Success)
                return 2;
            if (Regex.Match(number.ToString(), "1$").Success)
                return 0;
            if (Regex.Match(number.ToString(), "(2|3|4)$").Success)
                return 1;
            return 2;
        }

        public static string GetDayOnSiteStatus(DateTime date)
        {
            var days = new string[]
                {
                    "день",
                    "дня",
                    "дней"
                };

            var differenceTime = DateTime.UtcNow - date;

            if (Equals(Convert.ToInt32(differenceTime.TotalDays), 0))
                return string.Format("1 день");
            
            int timeSpan = Convert.ToInt32(differenceTime.TotalDays);
            return string.Format("{0} {1}", timeSpan, days[getWordEnd(timeSpan)]);
        }

        public static string GetActivityStatus(DateTime date)
        {
            #region data

            string[] mins = new string[]
                {
                    "минуту",
                    "минуты",
                    "минут"
                };

            string[] hours = new string[]
                {
                    "час",
                    "часа",
                    "часов"
                };

            string[] days = new string[]
                {
                    "день",
                    "дня",
                    "дней"
                };

            #endregion

            var differenceTime = DateTime.UtcNow - date;
            int timeSpan;
            const string onlineStatus = "Онлайн";
            const string offlineStatus = "Оффлайн";

            if (differenceTime.TotalMinutes < 60)
            {
                if (Convert.ToInt32(differenceTime.TotalMinutes) < 5)
                    return onlineStatus;
                
                timeSpan = Convert.ToInt32(differenceTime.TotalMinutes);
                return string.Format("Был на сайте: {0} {1} назад", timeSpan, mins[getWordEnd(timeSpan)]);
            }

            if (differenceTime.TotalMinutes >= 60 && differenceTime.TotalMinutes < 1440)
            {
                timeSpan = Convert.ToInt32(differenceTime.TotalHours);
                return string.Format("Был на сайте: {0} {1} назад", timeSpan, hours[getWordEnd(timeSpan)]);
            }
            else
            {
                timeSpan = Convert.ToInt32(differenceTime.TotalDays);
                return string.Format("Был на сайте: {0} {1} назад", timeSpan, days[getWordEnd(timeSpan)]);
            }
            return offlineStatus;
        }

        #endregion

        
    }
}