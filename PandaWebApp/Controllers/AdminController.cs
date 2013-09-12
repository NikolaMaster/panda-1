using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class AdminController : ModelCareController
    {
        public ActionResult Panel1(Guid pageId)
        {
            var staticPageUnit = DataAccessLayer.Get<StaticPageUnit>(x => x.Id == pageId).First();

            var entry = new StaticPage();
            var binder = new StaticPageToStaticPageUnit();
            binder.InverseLoad(staticPageUnit, entry);
            return View(entry);
        }

        //TODO: replace, because very dangerous =)
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Panel1(StaticPageUnit page)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer.UpdateById<StaticPageUnit>(page.Id, x =>
                    {
                        x.Content = page.Content;
                    });
                DataAccessLayer.DbContext.SaveChanges();
             
                return RedirectToAction("Index", "StaticPage", new { code = page.Code });
            }

            return View();
        }

        public ActionResult EditCoins(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            var pTuple = new Tuple<Guid, int>(userId,user.Coins);
            return View(pTuple);
        }

        [HttpPost]
        public ActionResult EditCoins(Tuple<Guid,int> pTuple)
        {
            DataAccessLayer.UpdateById<UserBase>(pTuple.Item1, x => x.Coins = pTuple.Item2);
            DataAccessLayer.DbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        
    }
}
