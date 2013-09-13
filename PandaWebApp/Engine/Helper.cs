using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Engine
{
    public static class Helper
    {
        #region Exceptions

        public static void HttpUnauthorized(string message = "Unauthorized")
        {
            throw new HttpException(401, message);
        }

        public static void HttpForbidden(string message = "Forbidden")
        {
            throw new HttpException(403, message);
        }

        #endregion

        #region Strings

        public static string Trim(this string src, int length)
        {
            if (src.Length > length)
            {
                src = src.Substring(0, length - 3) + "...";
            }
            return src;
        }

        #endregion
    }
}