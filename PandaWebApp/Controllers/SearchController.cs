using System.Security.Cryptography;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Engine.Logic;
using PandaWebApp.Filters;
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

        [NonAction]
        private EmployerSearchForm getModel(UserBase user)
        {
            var model = new EmployerSearchForm(DataAccessLayer);

            ValueFromAttributeConverter.ModelFromAttributes(model, user.MainChecklist.AttrbuteValues, DataAccessLayer);
            foreach (var desiredWork in DataAccessLayer.GetDesiredWork(user.MainChecklist.Id))
            {
                foreach (var modelDesiredWork in model.DesiredWork)
                {
                    if (modelDesiredWork.Code == desiredWork.Work.Code)
                    {
                        modelDesiredWork.Value = true;
                    }
                }
            }
            return model;
        }

        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult OffersCount(Guid id)
        {

            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.EmployerChecklistTypeCode);

            var formValues = new Dictionary<Attrib, object>();
            var formBinder = new FormEmployerSearchToSearchValues(DataAccessLayer);

            var user = DataAccessLayer.GetById<PromouterUser>(id);

            var model = getModel(user);
            formBinder.Load(model, formValues);

            var searchResult = (new Searcher(DataAccessLayer)).Search(searchCollection, formValues, model.Query).Count();
            return PartialView(searchResult);
        }

        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult Offers(Guid id)
        {
            var user = DataAccessLayer.GetById<PromouterUser>(id);
            var model = new EmployerSearchForm(DataAccessLayer);
            ValueFromAttributeConverter.ModelFromAttributes(model, user.MainChecklist.AttrbuteValues, DataAccessLayer);
            foreach (var desiredWork in DataAccessLayer.GetDesiredWork(user.MainChecklist.Id))
            {
                foreach (var modelDesiredWork in model.DesiredWork)
                {
                    if (modelDesiredWork.Code == desiredWork.Work.Code)
                    {
                        modelDesiredWork.Value = true;
                    }
                }
            }
            var genderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode).ToList();
            genderValues.ForEach(x =>
            {
                if (x.Value == model.Gender)
                    x.Selected = true;
            });
            var salaryValues = DataAccessLayer.ListItemsFromDict(Constants.SalaryCode).ToList();
            salaryValues.ForEach(x =>
            {
                if (x.Value == model.Salary)
                    x.Selected = true;
            });
            var cityValues =  DataAccessLayer.ListItemsFromDict(Constants.CityCode).ToList();
            cityValues.ForEach(x =>
            {
                if (x.Value == model.City)
                    x.Selected = true;
            });
            ViewBag.CityValues = cityValues;
            ViewBag.GenderValues = genderValues;
            ViewBag.SalaryValues = salaryValues;
            ViewBag.AutoSubmit = true;


            return View("Employer", model);
        }


        [HttpPost]
        public ActionResult EmployerSearchResult(EmployerSearchForm model)
        {

            var searchCollection = DataAccessLayer.Get<Checklist>(x => x.ChecklistType.Code == Constants.EmployerChecklistTypeCode);

            var formValues = new Dictionary<Attrib, object>();
            var formBinder = new FormEmployerSearchToSearchValues(DataAccessLayer);

            formBinder.Load(model, formValues);

            var searchResult = (new Searcher(DataAccessLayer)).Search(searchCollection, formValues, model.Query);

            var viewBinder = new VacancyToChecklist(DataAccessLayer);
            var resultModel = searchResult.Select(x =>
            {
                var t = new Vacancy();
                viewBinder.InverseLoad(x, t);
                return t;
            }).GetPaginator(model.Pager.Page, model.Pager.PerPage);
            ViewBag.Pager = resultModel.Pager;
            return PartialView(@"Vacancies", resultModel.Collection);
        }

        [HttpGet]
        public ActionResult Promouter()
        {
            var model = new PromouterSearchForm();

            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.SalaryValues = DataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? -1 : int.Parse(x.Text));
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);
            ViewBag.EducationValues = DataAccessLayer.ListItemsFromDict(Constants.EducationCode);
            var dates = DataAccessLayer.Get<Checklist>(
                x => x.ChecklistType.Code == Constants.PromouterChecklistTypeCode)
                .Select(x => DataAccessLayer.GetAttributeValue(x.Id, Constants.DateOfBirthCode))
                .Where(x => x != null && !string.IsNullOrEmpty(x.Value))
                .Select(x => Helper.GetFullYears(DateTime.Parse(x.Value))).ToList();

            ViewBag.MinAge = model.MinAge = dates.Min();
            ViewBag.MaxAge = model.MaxAge = dates.Max();
            
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
            }).GetPaginator(model.Pager.Page, model.Pager.PerPage);
            ViewBag.Pager = resultModel.Pager;
            return PartialView(resultModel.Collection);
        }


    }
}
