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
        public const int FeedbacksCount = 10;
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Feedback() 
        {
            var binder = new FeedbackToReview();
            var feedback = new Feedback
            {
                Count = DataAccessLayer.Count<Review>(),
                Entries = DataAccessLayer.TopRandom<Review>(FeedbacksCount).Select(x =>
                {
                    var entry = new Feedback.Entry();
                    binder.InverseLoad(x, entry);
                    return entry;
                }).ToList()
            };
            return PartialView(feedback);
        }

        public ActionResult OnlineUsers()
        {
            return PartialView(DataAccessLayer.OnlineUsers<UserBase>());
        }

        public ActionResult PandaPulse() 
        {
            var pandaPulse = new PandaPulse
            {
                Online = DataAccessLayer.OnlineUsers<UserBase>(),
                Items = DataAccessLayer.TopRandom<UserBase>(OnlineUsersCount)
                    .Select(x => new PandaPulse.Entry
                        {
                            //TODO: default avatar  for new users
                            Image = (x.Avatar != null ?  x.Avatar.SourceUrl : string.Empty),
                            Name = x.FirstName
                        })
            };
            return PartialView(pandaPulse);
        }
    }
}
