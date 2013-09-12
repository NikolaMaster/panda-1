using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Helpers
{
    public static class DataAccessLayerExtensions
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

    }
}
