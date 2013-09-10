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
