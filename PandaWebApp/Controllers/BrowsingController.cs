using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class BrowsingController : ModelCareController
    {
        [NonAction]
        public Browsing GenerateModel(DateTime end)
        {
            var model = new Browsing
            {
                Start = end.AddDays(-Browsing.Days),
                End = end
            };
            var binder = new BrowsingToValueItem(DataAccessLayer);
            model.Values = DataAccessLayer
                .GetBrowsingValues(CurrentUser.Id, model.Start, model.End)
                .Select(x => x)
                .ToDictionary(
                    key => key.Key, 
                    value => value.Value.Select(x =>
                    {
                        var b = new Browsing.ValueItem();
                        binder.Load(x, b);
                        return b;
                    }));
            model.JsonValues = JsonConvert.SerializeObject(model.Values);
            return model;
        }

        [BaseAuthorizationReuired]
        public ActionResult Index()
        {
            return View(GenerateModel(DateTime.UtcNow));
        }

        [BaseAuthorizationReuired]
        [HttpPost]
        public ActionResult Index(Browsing model)
        {
            return View(GenerateModel(model.End));
        }
    }
}
