using System.Net;
using System.Text;
using System.Web.Http;
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

        public static Encoding DefaultEncoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }

        #region Exceptions

        public static ActionResult HttpUnauthorized()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

        public static ActionResult HttpForbidden()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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

        #region Browsing

        public static void TryToCreateBrowsing(Guid what, AuthorizationCore auth, DataAccessLayer dal, bool whatIsPromouter)
        {
            if (auth.IsGuest)
            {
                return;
            }

            if ((whatIsPromouter && auth.IsEmployer) || (!whatIsPromouter && auth.IsPromouter))
            {
                dal.CreateBrowsing(auth.User.Id, what);
            }
        }

        #endregion

        #region Http stuff

        public static string HttpGet(this string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = DefaultEncoding;
                var res = client.DownloadString(url);
                return res;
            }
        }

        public static string HttpPost(this string url, string data)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                return client.UploadString(url, data);
            }
        }

        #endregion

    }
}