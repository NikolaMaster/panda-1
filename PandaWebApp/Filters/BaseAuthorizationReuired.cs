using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Filters
{
    public class BaseAuthorizationReuired : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            //TODO
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthorizationCore.StaticCreate().IsGuest)
            {
                var url = filterContext.RequestContext.HttpContext.Request.RawUrl;
                var routeParams = new System.Web.Routing.RouteValueDictionary { { WebConstants.LoginRetUrlParameterName, url } };
                filterContext.Result = new RedirectToRouteResult(WebConstants.LoginRouteName, routeParams);
            }
        }
    }
}