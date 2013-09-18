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
                                if (!string.IsNullOrEmpty(stringValue))
                                {
                                    var salary = DataAccessLayer.Get<DictValue>(stringValue);
                                    var costForHour = double.Parse(salary.Description);
                                    promoutersCostSum += costForHour;
                                }
                                break;
                        }
                    }
                }
                
                homeView.AveragePromouterCost = Math.Round(promoutersCostSum/homeView.TotalPromouters, 0);
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
                double totalAverageCostEmployers = 0;

                foreach (var employerUser in totalEmployersUserBase)
                {
                    string dictValue = null;
                    double totalAverageCostEmployer = 0;

                    var checklistEmpl =
                        employerUser.Checklists.Where(
                            x => x.ChecklistType == DataAccessLayer.Constants.EmployerChecklistType);

                    if (checklistEmpl.Any())
                    {
                        foreach (var checklist in checklistEmpl)
                        {
                            foreach (var attrib in checklist.AttrbuteValues)
                            {
                                if (attrib.Attrib.AttribType.DictGroup != null && attrib.Value != null &&
                                    attrib.Attrib.Code == Constants.SalaryCode)
                                {
                                    dictValue = DataAccessLayer.Get<DictValue>(attrib.Value).Description;
                                    totalAverageCostEmployer += Convert.ToInt32(dictValue);
                                    break;
                                }
                            }
                        }
                        totalAverageCostEmployer /= checklistEmpl.Count();
                    }

                    totalAverageCostEmployers += totalAverageCostEmployer;
                }
                totalAverageCostEmployers /= totalEmployersUserBase.Count();
                homeView.AverageEmployerCost = Math.Round(totalAverageCostEmployers, 0);
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
                Items = DataAccessLayer.GetPulseUsers(OnlineUsersCount)
                    .Select(x =>
                    {
                        var t = new PandaPulse.Entry();
                        binder.InverseLoad(x.UserBase, t);
                        t.Operation = x.Operation.Description;
                        return t;
                    })
            };
            return PartialView(pandaPulse);
        }

    }
}
