using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        #region Helpers

        [NonAction]
        public ActionResult WhereToRedirect(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToRoute(WebConstants.MainPageRouteName);
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        #endregion

        #region Login

        public ActionResult Login(string returnUrl)
        {
            var model = new FormModels.Login();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(FormModels.Login model)
        {
            if (ModelState.IsValid)
            {
                var res = AuthorizationCore.StaticCreate().Login(model.Email, model.Password);
                if (res)
                {
                    return WhereToRedirect(model.ReturnUrl);
                }
            }

            return View(model);
        }

        #endregion

        #region Logout

        public ActionResult Logout(string returnUrl)
        {
            AuthorizationCore.StaticCreate().Logout();
            return WhereToRedirect(returnUrl);
        }

        #endregion

    }
}
