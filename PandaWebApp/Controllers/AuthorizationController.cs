using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Filters;

namespace PandaWebApp.Controllers
{
    public class AuthorizationController : ModelCareController
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

        //public ActionResult Login(string returnUrl)
        //{
        //    var model = new FormModels.Login();
        //    model.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(FormModels.Login model)
        {
            if (ModelState.IsValid)
            {
                var res = AuthorizationCore.StaticCreate().Login(model.Email, model.Password);
                if (res)
                {
                    var core = AuthorizationCore.StaticCreate();
                    if (core.User is EmployerUser)
                    {
                        return Json(new { path = "/Employer/Detail/" + core.User.Id });
                        
                    }
                    else
                    {
                        return Json(new { path = "/Promouter/Detail/" + core.User.Id });
                    }
                }
            }

            return PartialView();
        }

        #endregion

        #region Logout

        [BaseAuthorizationReuired]
        public ActionResult Logout(string returnUrl)
        {
            AuthorizationCore.StaticCreate().Logout();
            return WhereToRedirect(returnUrl);
        }

        #endregion

        
        [HttpGet]
        public ActionResult Confirmation(Guid userId, string token)
        {
            var confirmRecord =
                DataAccessLayer.Get<Confirmation>(x => x.UserId == userId && x.Token == token).FirstOrDefault();

            if (confirmRecord != null)
            {
                var user = DataAccessLayer.Get<UserBase>(x => x.Id == userId).FirstOrDefault();
                if (user != null && (DateTime.UtcNow - user.CreationDate).Hours < 24)
                {
                    string isConfirm = "Ваш аккаунт подтвержден";
                    DataAccessLayer.DeleteById<Confirmation>(confirmRecord.Id);
                    DataAccessLayer.UpdateById<UserBase>(userId, x => x.IsConfirmed = true);
                    DataAccessLayer.DbContext.SaveChanges();
                    return View();
                }
                else
                {
                    DataAccessLayer.DeleteById<Confirmation>(confirmRecord.Id);
                    return HttpNotFound("404");
                }
            }

            return HttpNotFound("404");
        }
    }
}
