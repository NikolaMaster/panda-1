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

namespace PandaWebApp.Controllers
{
    public class EmployerController : ModelCareController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormModels.Register.Employer model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Employer model)
        {
            return View();
        }
    }
}
