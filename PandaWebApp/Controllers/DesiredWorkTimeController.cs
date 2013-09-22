using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class DesiredWorkTimeController : ModelCareController
    {
        public ActionResult Index(Guid userId)
        {
            ViewBag.SalaryValues = DataAccessLayer
                .ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? int.MaxValue : int.Parse(x.Text))
                .ToList();
            ViewBag.EducationValues = DataAccessLayer.ListItemsFromDict(Constants.EducationCode);
            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);
            ViewBag.CountryCodeValues = DataAccessLayer.ListItemsFromDict(Constants.MobilePhoneCode);

            return PartialView("Index", PromouterForm.Bind(DataAccessLayer, userId));
        }

        [BaseAuthorizationReuired]
        public ActionResult Delete(Guid desireWorkTimeId)
        {
            DataAccessLayer.DeleteById<DesiredWorkTime>(desireWorkTimeId);
            DataAccessLayer.DbContext.SaveChanges();
            return new EmptyResult();
        }

        [BaseAuthorizationReuired]
        public ActionResult Create(Guid userId)
        {
            var user = DataAccessLayer.GetById<PromouterUser>(userId);
            var attribValue = DataAccessLayer.GetAttributeValue(user.MainChecklist.Id, Constants.DesiredWorkTimeCode);
            Guid entityListId;
            var entityList = Guid.TryParse(attribValue.Value, out entityListId)
                ? DataAccessLayer.GetById<EntityList>(entityListId)
                : DataAccessLayer.Create(new EntityList());
            DataAccessLayer.Create(new DesiredWorkTime
            {
                EntityList = entityList
            });
            DataAccessLayer.DbContext.SaveChanges();
            return Index(userId);
        }

    }
}
