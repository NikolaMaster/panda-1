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
            Guid entityListId;
            var entityList = Guid.TryParse(attribValue.Value, out entityListId) 
                ? DataAccessLayer.GetById<EntityList>(entityListId) 
                : DataAccessLayer.Create(new EntityList());
            DataAccessLayer.Create(new WorkExpirience
            {
                EntityList = entityList,
            });
            DataAccessLayer.DbContext.SaveChanges();
            return Index(userId);
        }
    }
}
