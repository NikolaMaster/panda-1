using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
using System;
using System.Web.Mvc;

namespace PandaWebApp.Controllers
{
    public class WorkExperienceController : ModelCareController
    {
        public ActionResult Index(Guid userId)
        {
            return PartialView("Index", PromouterForm.Bind(DataAccessLayer, userId));
        }
        
        public ActionResult Delete(Guid workExperienceId) 
        {
            DataAccessLayer.DeleteById<WorkExpirience>(workExperienceId);
            DataAccessLayer.DbContext.SaveChanges();
            return new EmptyResult();
        }

        public ActionResult Create(Guid userId)
        {
            var user = DataAccessLayer.GetById<PromouterUser>(userId);
            var attribValue = DataAccessLayer.GetAttributeValue(user.Checklist.Id, Constants.WorkExperienceCode);
            var entityListId = Guid.Parse(attribValue.Value);
            var workExperience = DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = DataAccessLayer.GetById<EntityList>(entityListId)
            });
            DataAccessLayer.DbContext.SaveChanges();
            ViewBag.WorkExperienceId = workExperience.Id;
            return Index(userId);
        }
    }
}
