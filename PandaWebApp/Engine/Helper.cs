using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Engine
{
    public class Helper
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
    }
}