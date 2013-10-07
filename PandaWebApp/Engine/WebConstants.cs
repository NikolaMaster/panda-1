using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine
{
    public static class WebConstants
    {
        public const string UrlDelimiter = "/";

        #region Authorization

        public const string AuthorizationControllerName = "Authorization";
        public const string LoginActionName = "Login";
        public const string LoginUrl = AuthorizationControllerName + UrlDelimiter + LoginActionName;
        public const string LoginRouteName = "Login";
        public const string LoginRetUrlParameterName = "returnUrl";

        #endregion

        public const string MainPageRouteName = "Main";
        public const string MainPageControllerName = "Home";
        public const string MainPageActionName = "Index";
        public const string MainPageUrl = MainPageControllerName + UrlDelimiter + MainPageActionName;

        public const int PhotoPerRow = 5;
        public const int PhotoHeight = 120;
        public const int PhotoWidth = 150;
        public const int FeedbacksPerPage = 2;

        public const string NoPhoto = "~/Content/img/no_photo.jpg";
    }

}