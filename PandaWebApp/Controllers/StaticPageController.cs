using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    public class StaticPageController : ModelCareController
    {
        public ActionResult Index(string actionName, string controllerName, bool isPartial = false)
        {
            var staticPage =
                DataAccessLayer.Get<StaticPageUnit>(
                    x => x.MvcAction.Action == actionName && x.MvcAction.Controller == controllerName).FirstOrDefault();
            if (staticPage != null)
            {
                var binder = new StaticPageToStaticPageUnit(DataAccessLayer);
                var entry = new StaticPage();
                binder.InverseLoad(staticPage, entry);
                ViewBag.Title = entry.SeoEntry.Title;
                ViewBag.Keywords = entry.SeoEntry.Keyword;
                ViewBag.Description = entry.SeoEntry.Description;

                if (isPartial)
                {
                    return PartialView(entry);
                }
                else
                {
                    return View(entry);
                }
            }

            return HttpNotFound("Page not found");
        }


        public ActionResult About()
        {
             return RedirectToAction("Index", new {actionName = "About",controllerName = "StaticPage"});
        }

        public ActionResult Dictionary()
        {
            return RedirectToAction("Index", new { actionName = "Dictionary", controllerName = "StaticPage" });
        }

        public ActionResult Fivereasons()
        {
            //return PartialView("Index", new { actionName = "Fivereasons", controllerName = "StaticPage", isPartial = true });
            var staticPage =
                DataAccessLayer.Get<StaticPageUnit>(
                    x => x.MvcAction.Action == "Fivereasons" && x.MvcAction.Controller == "StaticPage").FirstOrDefault();
            if (staticPage != null)
            {
                var binder = new StaticPageToStaticPageUnit(DataAccessLayer);
                var entry = new StaticPage();
                binder.InverseLoad(staticPage, entry);
                ViewBag.Title = entry.SeoEntry.Title;
                ViewBag.Keywords = entry.SeoEntry.Keyword;
                ViewBag.Description = entry.SeoEntry.Description;


                return PartialView("Index",entry);
            }

            return HttpNotFound("Page not found");

        }

        public ActionResult FAQ()
        {
            return RedirectToAction("Index", new { actionName = "FAQ", controllerName = "StaticPage" });
        }

        public ActionResult Contacts()
        {
            return RedirectToAction("Index", new { actionName = "Contacts", controllerName = "StaticPage" });
        }

        public ActionResult PaidServices()
        {
            return RedirectToAction("Index", new { actionName = "PaidServices", controllerName = "StaticPage" });
        }

        public ActionResult Commercial()
        {
            return RedirectToAction("Index", new { actionName = "Commercial", controllerName = "StaticPage" });
        }

        public ActionResult SiteTerms()
        {
            return RedirectToAction("Index", new { actionName = "SiteTerms", controllerName = "StaticPage" });
        }
        public ActionResult ToWorker()
        {
            return RedirectToAction("Index", new { actionName = "ToWorker", controllerName = "StaticPage" });
        }

        public ActionResult Regulations()
        {
            return RedirectToAction("Index", new { actionName = "Regulations", controllerName = "StaticPage" });
        }

        public ActionResult Applicants()
        {
            return RedirectToAction("Index", new { actionName = "Applicants", controllerName = "StaticPage" });
        }

        public ActionResult Newcomers()
        {
            return RedirectToAction("Index", new { actionName = "Newcomers", controllerName = "StaticPage" });
        }

        public ActionResult UsefulArticles()
        {
            return RedirectToAction("Index", new { actionName = "UsefulArticles", controllerName = "StaticPage" });
        }

        public ActionResult Help()
        {
            return RedirectToAction("Index", new { actionName = "Help", controllerName = "StaticPage" });
        }
        
        [AdministratorAuthorizationRequired]
        public ActionResult EditStaticPage(Guid pageId)
        {
            var staticPageUnit = DataAccessLayer.Get<StaticPageUnit>(x => x.Id == pageId).First();

            var entry = new StaticPage();
            var binder = new StaticPageToStaticPageUnit(DataAccessLayer);
            binder.InverseLoad(staticPageUnit, entry);
            return View(entry);
        }
        
        [ValidateInput(false)]
        [HttpPost]
        [AdministratorAuthorizationRequired]
        public ActionResult EditStaticPage(StaticPage page)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer.UpdateById<StaticPageUnit>(page.Id, x =>
                {
                    x.Content = page.Content;
                });

                DataAccessLayer.UpdateById<SeoEntry>(page.SeoEntry.Id, x =>
                    {
                        x.Title = page.SeoEntry.Title;
                        x.Keyword = page.SeoEntry.Keyword;
                        x.Description = page.SeoEntry.Description;
                    });

                DataAccessLayer.DbContext.SaveChanges();

                return RedirectToAction(page.MvcAction.Action, page.MvcAction.Controller);
            }

            return View();
        }



    }
}
