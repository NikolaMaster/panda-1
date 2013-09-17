using System.Linq;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


using PandaWebApp.Engine.Binders;
using PandaDataAccessLayer.Entities;
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

            var pTuple = new Tuple<Promouter, List<string>>(model, listBought);

            return View(pTuple);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
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

            var binder = new FormPromouterToUsers(DataAccessLayer);
            var user = DataAccessLayer.GetById<PromouterUser>(id);
            var model = new PromouterForm();
            binder.InverseLoad(user, model);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PromouterForm model, IEnumerable<HttpPostedFileBase> photos)
        {
            if (ModelState.IsValid)
            {
                model.NewPhotos = photos == null ? new List<HttpPostedFileBase>() : photos.Where(x => x != null);
                var user = DataAccessLayer.GetById<PromouterUser>(model.UserId);
                var editor = new PromouterEditor(DataAccessLayer);
                editor.Edit(model, user);
                DataAccessLayer.DbContext.SaveChanges();
                return new RedirectResult(string.Format("/Promouter/Edit/{0}", model.UserId));
            }
            
#if DEBUG
            throw new Exception("ModelState is invalid");
#else
            return new EmptyResult();
#endif
        }
    }
}
