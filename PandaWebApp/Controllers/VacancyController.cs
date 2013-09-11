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
