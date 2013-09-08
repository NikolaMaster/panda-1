using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class DesiredWorkTimeController : ModelCareController
    {
        public ActionResult Index(Guid userId)
        {
            return PartialView("Index", PromouterForm.Bind(DataAccessLayer, userId));
        }

        public ActionResult Delete(Guid desireWorkTimeId)
        {
            DataAccessLayer.DeleteById<DesiredWorkTime>(desireWorkTimeId);
            DataAccessLayer.DbContext.SaveChanges();
            return new EmptyResult();
        }

        public ActionResult Create(Guid userId)
        {
            var user = DataAccessLayer.GetById<PromouterUser>(userId);
            var attribValue = DataAccessLayer.GetAttributeValue(user.Checklist.Id, Constants.DesiredWorkTimeCode);
            var entityListId = Guid.Parse(attribValue.Value);
            var desiredWorkTime = DataAccessLayer.Create(new DesiredWorkTime
            {
                EntityList = DataAccessLayer.GetById<EntityList>(entityListId)
            });
            DataAccessLayer.DbContext.SaveChanges();
            ViewBag.DesiredWorkTimeId = desiredWorkTime.Id;
            return Index(userId);
        }

    }
}
