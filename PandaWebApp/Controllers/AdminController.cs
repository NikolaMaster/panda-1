using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class AdminController : ModelCareController
    {
/*
        public ActionResult _editCoinsPartial(bool success, Guid userId)
        {
            if (!success)
            {
                return Json(new
                {
                    errorMessage = "Недостаточно монеток"
                });
            }
            var userBase = DataAccessLayer.GetById<UserBase>(userId);


        }

        */

        private void changeByCode(UserBase autorizeUser, Guid userId, IEnumerable<string> attr)
        {
            var isBought =
                DataAccessLayer.Get<CoinsInfo>(x => x.BuyUser == autorizeUser.Id && x.UserId == userId)
                    .All(x => attr.Any(y => y == x.Code.Code));
            if (!isBought)
            {
                foreach (var attrib in attr)
                {
                    DataAccessLayer.Create(new CoinsInfo()
                    {
                        Id = Guid.NewGuid(),
                        BuyUser = autorizeUser.Id,
                        UserId = userId,
                        Code = DataAccessLayer.Get<Attrib>(attrib)
                    }); 
                }

                DataAccessLayer.UpdateById<UserBase>(autorizeUser.Id, x => x.Coins = x.Coins - 1);
                DataAccessLayer.DbContext.SaveChanges();
            }
        }

        [HttpPost]
        [BaseAuthorizationReuired]
        public ActionResult ChangeCoins(Guid buyerId, Guid userId)
        {
            if (Request.IsAjaxRequest())
            {
                var userBase = DataAccessLayer.GetById<UserBase>(buyerId);
                var user = DataAccessLayer.GetById<PromouterUser>(userId);
                var attrCode = new[] {Constants.MobilePhoneCode, Constants.EmailCode, Constants.LastNameCode};
                if (userBase.Coins > 0)
                {
                    var binder = new ViewPromouterToUsers(DataAccessLayer);
                    var promouter = new Promouter();
                    binder.InverseLoad(user, promouter);
                    changeByCode(userBase, userId, attrCode);
                    return Json(new
                    {
                        phone = promouter.Phone.ToString(),
                        email = promouter.Email,
                        name = promouter.LastName
                    });
                }
                else
                {
                    return Json(new
                    {
                        errorMessage = "Недостаточно монеток"
                    });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AdministratorAuthorizationRequired]
        public ActionResult EditUserCoins(Guid userId)
        {
            var userBase = DataAccessLayer.GetById<UserBase>(userId);
            var user = new EditCoinsForm()
            {
                UserId = userBase.Id,
                Coins = userBase.Coins
            };

            return View(user);
        }

        [HttpPost]
        [AdministratorAuthorizationRequired]
        public ActionResult EditUserCoins(EditCoinsForm user)
        {
            DataAccessLayer.UpdateById<UserBase>(user.UserId, x => x.Coins = user.Coins);
            DataAccessLayer.DbContext.SaveChanges();
            var userBase = DataAccessLayer.GetById<UserBase>(user.UserId);
            var promouter = userBase as PromouterUser;
            var employer = userBase as EmployerUser;
            if (promouter == null && employer == null)
            {
                throw  new Exception("Incorrect user type");
            }

            return RedirectToAction("Detail", promouter == null ? "Employer" : "Promouter", new { id = user.UserId });
        }

    }
}
