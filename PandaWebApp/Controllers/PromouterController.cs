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

            var model = new ViewModels.Promouter();
            var binder = new ViewPromouterToUsers();
            binder.InverseLoad(entry, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Promouter model)
        {
            if (ModelState.IsValid)
            {
                var allAttributes = DataAccessLayer.GetAllAttributes();
                var editor = new PromouterEditor(allAttributes);
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
