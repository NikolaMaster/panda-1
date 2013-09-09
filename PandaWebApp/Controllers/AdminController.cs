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
             
                return RedirectToAction("IndexStaticPage", "StaticPage", new { code = page.Code });
            }

            return View();
        }

    }
}
