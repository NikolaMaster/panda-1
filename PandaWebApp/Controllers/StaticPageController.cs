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
    public class StaticPageController : ModelCareController
    {
        public ActionResult IndexStaticPage(string code)
        {
            var staticPage = DataAccessLayer.Get<StaticPageUnit>(x => x.Code == code);
            if (staticPage.Count().Equals(0))
            {
                return HttpNotFound("Page not found"); 
            }

            var binder = new StaticPageToStaticPageUnit();
            var entry = new StaticPage();
            binder.InverseLoad(staticPage.First(), entry);
            return View(entry);
        }
    }
}
