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
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
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
