using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Engine.Logic;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Controllers
{
    public class SearchController : ModelCareController
    {
        [HttpGet]
        public ActionResult Employer()
        {
            var model = new EmployerSearchForm(DataAccessLayer);

            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.SalaryValues = DataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? -1 : int.Parse(x.Text));
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);

            return View(model);
        }

        [HttpPost]
        public ActionResult EmployerSearchResult(EmployerSearchForm model)
        {

            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.EmployerChecklistTypeCode);

            var formValues = new Dictionary<Attrib, object>();
            var formBinder = new FormEmployerSearchToSearchValues(DataAccessLayer);

            formBinder.Load(model, formValues);

            var searchResult = (new Searcher(DataAccessLayer)).Search(searchCollection, formValues, model.Query);

            var viewBinder = new ViewEmployerSearchViewToChecklist(DataAccessLayer);
            var resultModel = searchResult.Select(x =>
            {
                var t = new EmployerSearchView();
                viewBinder.InverseLoad(x, t);
                return t;
            });
            return PartialView(resultModel);
        }

        [HttpGet]
        public ActionResult Promouter()
        {
            var model = new PromouterSearchForm();

            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.SalaryValues = DataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? -1 : int.Parse(x.Text));
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);

            return View(model);
        }

        [HttpPost]
        public ActionResult PromouterSearchResult(PromouterSearchForm model)
        {

            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.PromouterChecklistTypeCode);

            var formValues = new Dictionary<Attrib, object>();
            var formBinder = new FormPromouterSearchToSearchValues(DataAccessLayer);

            formBinder.Load(model, formValues);

            var searchResult = (new Searcher(DataAccessLayer)).Search(searchCollection, formValues, model.Query);

            var viewBinder = new ViewPromouterSearchViewToChecklist(DataAccessLayer);
            var resultModel = searchResult.Select(x =>
            {
                var t = new PromouterSearchView();
                viewBinder.InverseLoad(x, t);
                return t;
            });
            return PartialView(resultModel);
        }


    }
}
