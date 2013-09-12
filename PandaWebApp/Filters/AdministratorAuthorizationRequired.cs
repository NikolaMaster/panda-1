using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Filters
{
    public class AdministratorAuthorizationRequired : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!AuthorizationCore.StaticCreate().IsAdmin)
            {
                Helper.HttpForbidden();
            }
        }
    }
}