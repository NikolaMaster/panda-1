using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PandaWebApp.Engine.Social
{
    public partial class OAuth
    {
        #region Base functions

        public static string ParamsString(Dictionary<string, object> parameters)
        {
            return string.Join("&", parameters.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
        }

        public static string BaseGetLink(string urlBase, Dictionary<string, object> parameters)
        {
            var url = urlBase;
            var tokens = HttpUtility.UrlDecode(ParamsString(parameters));
            return urlBase + tokens;
        }

        public static T BaseGetJson<T>(string urlBase, Dictionary<string, object> parameters)
        {
            return JsonConvert.DeserializeObject<T>(BaseGetLink(urlBase, parameters).HttpGet());
        }

        public static T BasePostJson<T>(string urlBase, Dictionary<string, object> parameters)
        {
            return JsonConvert.DeserializeObject<T>(BaseGetLink(urlBase, new Dictionary<string, object>()).HttpPost(ParamsString(parameters)));
        }

        #endregion
    }
}