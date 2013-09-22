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
        [NonAction]
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

        [HttpGet]
        [AdministratorAuthorizationRequired]
        public ActionResult AdminIndex()
        {
            return View("Index", GetModel(DataAccessLayer.GetAllFavorites()));
        }

        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult UserIndex()
        {
            return View("Index", GetModel(DataAccessLayer.GetUserFavorites(CurrentUser)));
        }

        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult _UserIndex()
        {
            return View("_Index", GetModel(DataAccessLayer.GetUserFavorites(CurrentUser)));
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult AddToFavorite(Guid id)
        {
            var viewName = DataAccessLayer.AddToFavorites(CurrentUser.Id, id)
                ? "_SuccessAdd" 
                : "_FailAdd";
            return PartialView(viewName);
        }

        [HttpPost]
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
