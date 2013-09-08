using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Engine.Editors;
using PandaWebApp.ViewModels;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class EmployerController : ModelCareController
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult TopEmployers(int count)
        {
            var topEmployersUserBase = DataAccessLayer.TopRandom<EmployerUser>(count);
            var models = new List<Employer>();
            foreach (var employerUserBase in topEmployersUserBase)
            {
                var model = new Employer();
                var binder = new ViewEmployerToUser(DataAccessLayer);
                binder.InverseLoad(employerUserBase, model);
                models.Add(model);
            }
            
            return PartialView(models);
        }

        [HttpPost]
        public ActionResult Create(FormModels.Register.Employer model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Password.MakePassword(model.Password, DateTime.UtcNow);
                var binder = new RegisterEmployerToUsers();
                var entry = new EmployerUser();
                binder.Load(model, entry);
                DataAccessLayer.Create(entry);
                DataAccessLayer.DbContext.SaveChanges();

                return RedirectToAction("Detail", new { id = entry.Id });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var entry = DataAccessLayer.GetById<EmployerUser>(id);
            if (entry == null)
            {
                return HttpNotFound("Employer not found");
            }

            var model = new Employer();
            var binder = new ViewEmployerToUser(DataAccessLayer);
            binder.InverseLoad(entry, model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var binder = new ViewEmployerToUser(DataAccessLayer);
            var user = DataAccessLayer.GetById<EmployerUser>(id);
            var model = new EmployerForm(DataAccessLayer);
            binder.InverseLoad(user, model);
            return View(model);
        }
    }
}
