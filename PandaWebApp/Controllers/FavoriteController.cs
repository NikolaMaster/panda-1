using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL = PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Filters;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class FavoriteController : ModelCareController
    {
        public static int FavoritePrice = 3;
        public static int FavoritePackage = 2;

        public class FavoriteActionResultObject
        {
            public string Text { get; set; }
            public Enum Code { get; set; }
            public string NextStep { get; set; }
            public Guid? NextStepArg { get; set; }
            public string Callback { get; set; }

            public FavoriteActionResultObject(string text, Enum code, string next = "", Guid? nextStepArg = null, string callback = "")
            {
                Text = text;
                Code = code;
                NextStep = next;
                NextStepArg = nextStepArg;
                Callback = callback;
            }

            public FavoriteActionResultObject(string text, Enum code, string callback)
            {
                Text = text;
                Code = code;
                Callback = callback;
            }
        }

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
            return PartialView("_Index", GetModel(DataAccessLayer.GetUserFavorites(CurrentUser)));
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public JsonResult AddToFavorite(Guid id)
        {
            var text = new Dictionary<DAL.DataAccessLayer.AddToFavoritesResult, string>
            {
                {DAL.DataAccessLayer.AddToFavoritesResult.NeedToBuy, "Необходимо заплатить, продолжить?"},
                {DAL.DataAccessLayer.AddToFavoritesResult.Ok, "Запись успешно добавлена в избранное."},
                {DAL.DataAccessLayer.AddToFavoritesResult.WrongTypes, "Операция невозможна!"}
            };
            var res = DataAccessLayer.AddToFavorites(CurrentUser.Id, id);
            var nextStep = res == DAL.DataAccessLayer.AddToFavoritesResult.NeedToBuy ? "BuyFavorites" : "";
            var nextStepArg = res == DAL.DataAccessLayer.AddToFavoritesResult.NeedToBuy ? (Guid?) id : null;
            var callback = res == DAL.DataAccessLayer.AddToFavoritesResult.Ok ? "updateUserInfo()" : "";
            return Json(new FavoriteActionResultObject(text[res], res, nextStep, nextStepArg, callback));
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public JsonResult DeleteFromFavorite(Guid id)
        {
            var text = new Dictionary<DAL.DataAccessLayer.DeleteFromFavoritesResult, string>
            {
                {DAL.DataAccessLayer.DeleteFromFavoritesResult.Ok, "Запись успешно удалена."},
                {DAL.DataAccessLayer.DeleteFromFavoritesResult.NotFound, "Запись не найдена!"}
            };
            var res = DataAccessLayer.DeleteFromFavorite(id);
            var callback = res == DAL.DataAccessLayer.DeleteFromFavoritesResult.Ok ? "$.when(updateUserInfo()).done(reloadFavoritesContent);" : "";
            return Json(new FavoriteActionResultObject(text[res], res, callback));
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult BuyFavorites(Guid? id)
        {
            var text = new Dictionary<DAL.DataAccessLayer.BuyFavoritesResult, string>
            {
                { DAL.DataAccessLayer.BuyFavoritesResult.NotEnoughMoney, "Недостаточно монет!"},
                { DAL.DataAccessLayer.BuyFavoritesResult.Ok, "Максимальное количество записей в избранном увеличено на " + FavoritePackage}
            };
            var res = DataAccessLayer.BuyFavorites(
                CurrentUser.Id,
                FavoritePrice,
                FavoritePackage);
            var nextStep = res == DAL.DataAccessLayer.BuyFavoritesResult.Ok ? "AddToFavorite" : "";
            var nextStepArg = res == DAL.DataAccessLayer.BuyFavoritesResult.Ok ? id : null;
            return Json(new FavoriteActionResultObject(text[res], res, nextStep, nextStepArg));
        }
    }
}
