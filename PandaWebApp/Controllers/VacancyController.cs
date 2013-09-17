using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class VacancyController : ModelCareController
    {
        public ActionResult Index(Guid userId)
        {
            ViewBag.SalaryValues = DataAccessLayer
                .ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? int.MaxValue : int.Parse(x.Text))
                .ToList();
            ViewBag.WorkValues = DataAccessLayer.ListItemsFromDict(Constants.WorkCode);
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);
            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.EducationValues = DataAccessLayer.ListItemsFromDict(Constants.EducationCode);
            ViewBag.CountryCodeValues = DataAccessLayer.ListItemsFromDict(Constants.MobilePhoneCode);

            return PartialView("Index", EmployerForm.Bind(DataAccessLayer, userId));
        }

        public ActionResult Delete(Guid vacancyId)
        {
            DataAccessLayer.DeleteById<Checklist>(vacancyId);
            DataAccessLayer.DbContext.SaveChanges();
            return new EmptyResult();
        }

        public ActionResult Create(Guid userId)
        {
            var user = DataAccessLayer.GetById<EmployerUser>(userId);
            DataAccessLayer.Create(user, DataAccessLayer.Constants.EmployerChecklistType, new LinkedList<AttribValue>());
            DataAccessLayer.DbContext.SaveChanges();
            return Index(userId);
        }

    }
}
