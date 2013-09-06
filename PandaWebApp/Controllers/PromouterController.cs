using System.Data.Entity;
using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using PandaWebApp.Engine.Binders;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.DAL;
using PandaWebApp.ViewModels;
using PandaWebApp.Engine.Editors;
using PandaWebApp.FormModels;

namespace PandaWebApp.Controllers
{
    public class PromouterController : ModelCareController
    {
        [HttpGet]
        public ActionResult Create()
        {
            var model = new FormModels.Register.Promouter();

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormModels.Register.Promouter model)
        {
            if (ModelState.IsValid)
            {
                //salt
                model.Password = Password.MakePassword(model.Password, DateTime.UtcNow);
                var binder = new RegisterPromouterToUsers();
                var entry = new PromouterUser();
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
            var entry = DataAccessLayer.GetById<PromouterUser>(id);
            if (entry == null)
            {
                return HttpNotFound("Promouter not found");
            }
           
            var model = new Promouter();
            var binder = new ViewPromouterToUsers(DataAccessLayer);
            binder.InverseLoad(entry, model);
          
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var binder = new ViewPromouterToUsers(DataAccessLayer);
            var user = DataAccessLayer.GetById<PromouterUser>(id);
            var model = new PromouterForm(DataAccessLayer);
            binder.InverseLoad(user, model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Promouter model)
        {
            if (ModelState.IsValid)
            {
                var allAttributes = DataAccessLayer.GetAllAttributes();
                var editor = new PromouterEditor(DataAccessLayer, allAttributes);
                var user = new PromouterUser();
                editor.Edit(model, user);
                DataAccessLayer.DbContext.SaveChanges();
                return Detail(model.UserId);
            }
            
#if DEBUG
            throw new Exception("ModelState is invalid");
#else
            return new EmptyResult();
#endif
        }

    }
}
