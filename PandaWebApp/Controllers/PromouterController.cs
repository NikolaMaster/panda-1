﻿using System.Data.Entity;
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

       
        public ActionResult TopPromouters(int count)
        {
            var topPromoutersUserBase = DataAccessLayer.TopRandom<PromouterUser>(count);
            var models = new List<Promouter>();
            foreach (var promouterUserBase in topPromoutersUserBase)
            {
                var model = new Promouter();
                var binder = new ViewPromouterToUsers(DataAccessLayer);
                binder.InverseLoad(promouterUserBase, model);
                models.Add(model);
            }

            return PartialView(models);
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
            var binder = new FormPromouterToUsers(DataAccessLayer);
            var user = DataAccessLayer.GetById<PromouterUser>(id);
            var model = new PromouterForm();
            binder.InverseLoad(user, model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PromouterForm model)
        {
            if (ModelState.IsValid)
            {
                var user = DataAccessLayer.GetById<PromouterUser>(model.UserId);
                var editor = new PromouterEditor(DataAccessLayer);
                editor.Edit(model, user);
                try
                {
                    DataAccessLayer.DbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                }
                
                return View(model);
            }
            
#if DEBUG
            throw new Exception("ModelState is invalid");
#else
            return new EmptyResult();
#endif
        }

    }
}
