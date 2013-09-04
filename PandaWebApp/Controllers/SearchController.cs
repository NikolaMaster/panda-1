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
        public ActionResult Company()
        {
            var model = new SearchForm(DataAccessLayer);
            return View(model);
        }

        [HttpPost]
        public ActionResult CompanySearchResult(SearchForm model)
        {
            var desiredWork = new List<DictValue>();
            desiredWork.AddRange(model.DesiredWork.Where(x => x.Value).Select(x => DataAccessLayer.Get<DictValue>(x.Code)));

            var searchValues = new Dictionary<Attrib, object>
            {
                { DataAccessLayer.Constants.DesiredWork, desiredWork }
            };
                
            var searcher = new Searcher(DataAccessLayer);
            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.CompanyChecklistTypeCode);
            var searchResult = searcher.Search(searchCollection, searchValues);
            var binder = new ViewSearchToChecklist(DataAccessLayer);
            var resultModel = searchResult.Select(x =>
            {
                var t = new SearchView();
                binder.InverseLoad(x, t);
                return t;
            });
            return PartialView(resultModel);
        }


    }
}
