using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PandaWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                WebConstants.LoginRouteName, 
                WebConstants.LoginUrl, 
                new 
                { 
                    controller = WebConstants.AuthorizationControllerName, 
                    action = WebConstants.LoginActionName,
                    returnUrl = UrlParameter.Optional
                });
            routes.MapRoute(
                WebConstants.MainPageRouteName,
                WebConstants.MainPageUrl,
                new
                {
                    controller = WebConstants.MainPageControllerName,
                    action = WebConstants.MainPageActionName
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}