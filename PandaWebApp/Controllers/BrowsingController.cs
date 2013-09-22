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
        public Browsing GenerateModel(DateTime dt, bool isStart)
        {
            var model = new Browsing
            {
                Start = isStart ? dt : dt.AddDays(-Browsing.Days),
                End = !isStart ? dt : dt.AddDays(Browsing.Days)
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
            model.JsonValues = JsonConvert.SerializeObject(model.Values.Select(x => new object[2]
            {
                x.Value.Count(),
                new { label = x.Key.ToPandaStringWithoutYear() }
            }));
            return model;
        }

        [BaseAuthorizationReuired]
        public ActionResult Index()
        {
            return View(GenerateModel(DateTime.UtcNow, false));
        }

        [BaseAuthorizationReuired]
        [HttpPost]
        public ActionResult Index(Browsing model)
        {
            if (model.End == DateTime.MinValue)
            {
                return View(GenerateModel(model.Start, true));
            }
            if (model.Start == DateTime.MinValue)
            {
                return View(GenerateModel(model.End, false));
            }
            return null;
        }
    }
}
