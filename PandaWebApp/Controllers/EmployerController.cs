using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.Helpers;
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

            var core = AuthorizationCore.StaticCreate();
            var listBought = new List<string>();

            var isBought =
               DataAccessLayer.Get<CoinsInfo>(x => x.BuyUser == core.User.Id && x.UserId == id && x.Code.Code == Constants.MobilePhoneCode)
                              .FirstOrDefault();
            if (isBought != null)
            {
                listBought.Add(Constants.MobilePhoneCode);
            }

            isBought =
               DataAccessLayer.Get<CoinsInfo>(x => x.BuyUser == core.User.Id && x.UserId == id && x.Code.Code == Constants.EmailCode)
                              .FirstOrDefault();

            if (isBought != null)
            {
                listBought.Add(Constants.EmailCode);
            }

            var pTuple = new Tuple<Employer, List<string>>(model, listBought);

            return View(pTuple);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            prepareViewBag();
            var binder = new FormEmployerToUser(DataAccessLayer);
            var user = DataAccessLayer.GetById<EmployerUser>(id);
            var model = new EmployerForm();
            binder.InverseLoad(user, model);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EmployerForm model, IEnumerable<HttpPostedFileBase> photos)
        {
            if (ModelState.IsValid)
            {
                model.NewPhotos = photos == null ? new List<HttpPostedFileBase>() : photos.Where(x => x != null);
                var user = DataAccessLayer.GetById<EmployerUser>(model.UserId);
                var editor = new EmployerEditor(DataAccessLayer);
                editor.Edit(model, user);
                DataAccessLayer.DbContext.SaveChanges();
                return new RedirectResult(string.Format("/Employer/Edit/{0}", model.UserId));
            }

#if DEBUG
            throw new Exception("ModelState is invalid");
#else
            return new EmptyResult();
#endif
        }


        private void prepareViewBag()
        {
            ViewBag.SalaryValues = DataAccessLayer
                .ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? int.MaxValue : int.Parse(x.Text))
                .ToList();
            ViewBag.WorkValues = DataAccessLayer.ListItemsFromDict(Constants.WorkCode);
            ViewBag.CityValues = DataAccessLayer.ListItemsFromDict(Constants.CityCode);
            ViewBag.GenderValues = DataAccessLayer.ListItemsFromDict(Constants.GenderCode);
            ViewBag.EducationValues = DataAccessLayer.ListItemsFromDict(Constants.EducationCode);
            ViewBag.CountryCodeValues = DataAccessLayer.ListItemsFromDict(Constants.MobilePhoneCode);
            ViewBag.CompanySubTypeValues = DataAccessLayer.ListItemsFromDict(Constants.CompanySubTypeCode);
        }

        [HttpGet]
        public ActionResult CreateCompany()
        {
            prepareViewBag();
            var model = new CompanyRegister();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult CreateCompany(CompanyRegister model)
        {
            prepareViewBag();
            if (ModelState.IsValid)
            {
                var binder = new EmployerRegisterToEmployerUser(DataAccessLayer);
                var user = DataAccessLayer.Create(new EmployerUser());
                binder.Load(model, user);
                DataAccessLayer.DbContext.SaveChanges();
                return PartialView(model);
            }
            return PartialView(model);
        }
    }
}
