using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Filters;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class FavoriteController : ModelCareController
    {
        [System.Web.Mvc.NonAction]
        private FavoriteViewModel GetModel(IEnumerable<Favorite> f)
        {
            return new FavoriteViewModel
            {
                Items = f.Select(x => new FavoriteViewModel.Item
                {
                    UserName = DataAccessLayer.GetPulseUserName(x.Like),
                    Controller = x.Like.ControllerNameByUser(),
                    Id = x.Id,
                    UserId = x.Like.Id
                })
            };
        }

        [System.Web.Mvc.HttpGet]
        [AdministratorAuthorizationRequired]
        public ActionResult AdminIndex()
        {
            return View("Index", GetModel(DataAccessLayer.GetAllFavorites()));
        }

        [System.Web.Mvc.HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult UserIndex()
        {
            return View("Index", GetModel(DataAccessLayer.GetUserFavorites(CurrentUser)));
        }

        [System.Web.Mvc.HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult _UserIndex()
        {
            return View("_Index", GetModel(DataAccessLayer.GetUserFavorites(CurrentUser)));
        }

        [System.Web.Mvc.HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult AddToFavorite(Guid id)
        {
            var viewName = DataAccessLayer.AddToFavorites(CurrentUser.Id, id)
                ? "_SuccessAdd" 
                : "_FailAdd";
            return PartialView(viewName);
        }

        [System.Web.Mvc.HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult DeleteFromFavorite(Guid id)
        {
            var viewName = 
                DataAccessLayer.DeleteFromFavorite(id)
                    ? "_SuccessDelete"
                    : "_FailDelete";
            return PartialView(viewName);
        }
    }
}
