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
        //
        // GET: /Search/
        [HttpGet]
        public ActionResult Employer()
        {
            var model = new SearchForm(DataAccessLayer);
            return View(model);
        }

        [HttpPost]
        public ActionResult EmployerSearchResult(SearchForm model)
        {

            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.EmployerChecklistTypeCode);

            var formValues = new Dictionary<Attrib, object>();
            var formBinder = new FormSearchToSearchValues(DataAccessLayer);

            formBinder.Load(model, formValues);

            var searchResult = (new Searcher(DataAccessLayer)).Search(searchCollection, formValues, model.Query);

            var viewBinder = new ViewSearchToChecklist(DataAccessLayer);
            var resultModel = searchResult.Select(x =>
            {
                var t = new SearchView();
                viewBinder.InverseLoad(x, t);
                return t;
            });
            return PartialView(resultModel);
        }


    }
}
