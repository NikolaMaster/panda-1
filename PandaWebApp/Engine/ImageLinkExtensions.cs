using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace PandaWebApp.Engine
{
    public static class ImageLinkExtensions
    {

        public static IHtmlString ImageActionLink(this AjaxHelper helper, string imageUrl, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);

            var link = helper.ActionLink("[replaceme]", actionName, controllerName, routeValues, ajaxOptions).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing)));
        }
    }
}