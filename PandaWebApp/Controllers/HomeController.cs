using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PandaWebApp.Controllers
{
    public class HomeController : ModelCareController
    {
        public const int OnlineUsersCount = 10;
        public const int TopPromoutersCount = 12;
        public const int TopEmployersCount = 5;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainView()
        {
            var homeView = new HomeView();

            var topPromoutersUserBase = DataAccessLayer.TopRandom<PromouterUser>(TopPromoutersCount);
            var topPromouterUsers = new List<Promouter>();
            foreach (var promouterUserBase in topPromoutersUserBase)
            {
                var model = new Promouter();
                var binder = new ViewPromouterToUsers(DataAccessLayer);
                binder.InverseLoad(promouterUserBase, model);
                topPromouterUsers.Add(model);
            }

            homeView.TopPromouters = topPromouterUsers;

            var totalPromoutersUserBase = DataAccessLayer.Get<PromouterUser>();
            homeView.TotalPromouters = totalPromoutersUserBase.Count();
            if (totalPromoutersUserBase.Any())
            {
                double promoutersCostSum = 0;
                foreach (var promouterUser in totalPromoutersUserBase)
                {
                    var checklist = promouterUser.Checklists.FirstOrDefault();
                    foreach (var attrib in checklist.AttrbuteValues)
                    {
                        var dateTimeValue = DateTime.UtcNow;
                        var stringValue = attrib.Value;
                        var intValue = 0;
                        var boolValue = true;

                        DateTime.TryParse(stringValue, out dateTimeValue);
                        int.TryParse(stringValue, out intValue);
                        bool.TryParse(stringValue, out boolValue);


                        switch (attrib.Attrib.Code)
                        {
                            case Constants.SalaryCode:
                                var costForHour = double.Parse(DataAccessLayer.Get<DictValue>(stringValue).Description);
                                promoutersCostSum += costForHour;
                                break;
                        }
                    }
                }

                homeView.AveragePromouterCost = promoutersCostSum/homeView.TotalPromouters;
            }

            var topEmployersUserBase = DataAccessLayer.TopRandom<EmployerUser>(TopEmployersCount);
            var topEmployerUsers = new List<Employer>();
            foreach (var employerUserBase in topEmployersUserBase)
            {
                var model = new Employer();
                var binder = new ViewEmployerToUser(DataAccessLayer);
                binder.InverseLoad(employerUserBase, model);
                topEmployerUsers.Add(model);
            }
            homeView.TopEmployers = topEmployerUsers;

            var totalEmployersUserBase = DataAccessLayer.Get<EmployerUser>();
            homeView.TotalEmployers = totalEmployersUserBase.Count();
            if (totalEmployersUserBase.Any())
            {
                double totalAverageCostEmployer = 0;
                foreach (var employerUser in totalEmployersUserBase)
                {
                    var checklist = employerUser.Checklists.FirstOrDefault();
                    double averageCostEmployer = 0;
                    bool flag = false;
                    foreach (var attrib in checklist.AttrbuteValues)
                    {
                        var stringValue = attrib.Value;

                        switch (attrib.Attrib.Code)
                        {
                            case Constants.VacancyCode:
                                var vacancies = DataAccessLayer.Get<Vacancy>(x => x.EntityList.Id == new Guid(stringValue));
                                if (vacancies.Any())
                                {
                                    foreach (var vacancy in vacancies)
                                    {
                                        averageCostEmployer += int.Parse(vacancy.CostOfHours.Description);
                                    }
                                    averageCostEmployer /= vacancies.Count();
                                }
                                flag = true;
                                break;
                        }
                    }

                    if (flag)
                    {
                        totalAverageCostEmployer += averageCostEmployer;
                        break;
                    }
                }
                totalAverageCostEmployer /= totalEmployersUserBase.Count();
                homeView.AverageEmployerCost = Math.Round(totalAverageCostEmployer,0);
            }

            return PartialView(homeView);
        }
        


        public ActionResult OnlineUsers()
        {
            return PartialView(DataAccessLayer.OnlineUsers());
        }

        public ActionResult PandaPulse() 
        {
            var binder = new PandaPulseToUserBase(DataAccessLayer);
            var pandaPulse = new PandaPulse
            {
                Online = DataAccessLayer.OnlineUsers(),
                Items = DataAccessLayer.TopRandom<UserBase>(OnlineUsersCount)
                    .Select(x =>
                    {
                        var t = new PandaPulse.Entry();
                        binder.InverseLoad(x, t);
                        return t;
                    })
            };
            return PartialView(pandaPulse);
        }

    }
}
