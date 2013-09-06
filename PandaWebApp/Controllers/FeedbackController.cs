using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;

namespace PandaWebApp.Controllers
{
    public class FeedbackController : ModelCareController
    {
        public const int UserFeedbacksCount = 4;
        public const int IndexFeedbacksCount = 4;

        private Feedback prepareFeedbacks(IEnumerable<Review> feedbacks, int count = 0)
        {
            var binder = new FeedbackToReview();
            var collection = count > 0 ? feedbacks.Take(count) : feedbacks;
            return new Feedback
            {
                Count = feedbacks.Count(),
                Entries = collection.Select(x => {
                    var result = new Feedback.Entry();
                    binder.InverseLoad(x, result);
                    return result;
                }).ToList(),


            }; 
        }

        public ActionResult Index()
        {
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>());
            return View(feedback);
        }

        public ActionResult IndexFeedback()
        {
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(), IndexFeedbacksCount);
            return PartialView(feedback);
        }

        public ActionResult UserFeedback(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            var type = user as EmployerUser;
            var feedback = prepareFeedbacks(user.Reviews, UserFeedbacksCount);
            feedback.UserType = type != null ? Constants.CompanyChecklistTypeCode : Constants.PromouterChecklistTypeCode;
            return PartialView(feedback);
        }
    }
}
