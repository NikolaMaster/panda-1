using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    [BaseAuthorizationReuired]
    public class UserInfoController : ModelCareController
    {
        public JsonResult Index()
        {
            var model = new UserInfo();
            var binder = new CurrentUserToUserInfo();
            binder.Load(null, model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
