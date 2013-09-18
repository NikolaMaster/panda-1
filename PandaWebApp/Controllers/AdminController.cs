using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class AdminController : ModelCareController
    {
        public ActionResult _editCoinsPartial(string value)
        {
            return PartialView(value);
        }


        private void changeByCode(UserBase autorizeUser, Guid userId, Attrib attr)
        {
            var isBought =
                DataAccessLayer.Get<CoinsInfo>(x => x.BuyUser == autorizeUser.Id && x.UserId == userId && x.Code.Code == attr.Code)
                               .FirstOrDefault();
            if (isBought == null)
            {
                DataAccessLayer.Create<CoinsInfo>(new CoinsInfo()
                    {
                        Id = Guid.NewGuid(),
                        BuyUser = autorizeUser.Id,
                        UserId = userId,
                        Code = attr
                    });

                DataAccessLayer.UpdateById<UserBase>(autorizeUser.Id, x => x.Coins = x.Coins - 1);
                DataAccessLayer.DbContext.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult ChangeCoins(Guid buyerId, Guid userId, string attrCode,string value)
        {
            if (Request.IsAjaxRequest())
            {
                var userBase = DataAccessLayer.GetById<UserBase>(buyerId);

                if (userBase.Coins > 0)
                {
                    Attrib attr = null;
                    if (attrCode == Constants.MobilePhoneCode)
                    {
                        attr = DataAccessLayer.Constants.MobilePhone;
                    }
                    else if (attrCode == Constants.EmailCode)
                    {
                        attr = DataAccessLayer.Constants.Email;
                    }

                    changeByCode(userBase, userId, attr);

                    return PartialView("_editCoinsPartial", value);
                }
                else
                {
                    return PartialView("_editCoinsPartial", "отсутствуют монеты");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
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
