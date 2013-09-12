using System.Collections.ObjectModel;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.FormModels;
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
            var binder = new FeedbackToReview(DataAccessLayer);
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

        [ActionName("IndexById")]
        public ActionResult Index(Guid userId)
        {
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(x => x.RecieverId == userId));
            return View("Index", feedback);
        }

        public ActionResult IndexFeedback()
        {
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(), IndexFeedbacksCount);
            return PartialView(feedback);
        }

        public ActionResult UserFeedback(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(x => x.RecieverId == userId), UserFeedbacksCount);
            var type = user as EmployerUser;
            feedback.User = user;
            return PartialView(feedback);
        }


        public ActionResult TopDialogFeedback()
        {

            var list = new List<Feedback.Entry>();
            int counter = 0;
            while (true)
            {
                var user = DataAccessLayer.TopRandom<PromouterUser>(3);
                foreach (var promouterUser in user)
                {
                    var review = DataAccessLayer.Get<Review>(x => x.AuthorId == promouterUser.Id);
                    if (review.Any())
                    {
                        var binder = new FeedbackToReview(DataAccessLayer);
                        var entry = new Feedback.Entry();
                        binder.InverseLoad(review.First(), entry);

                        list.Add(entry);
                        if (list.Count == 3)
                            break;
                    }
                }

                if (list.Count == 3)
                    break;

                counter++;

                if (counter > 1000)
                    break;

            }
            return PartialView(list);

        }

        public ActionResult TopUserFeedback(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(x => x.RecieverId == userId), UserFeedbacksCount);
            var type = user as EmployerUser;
            feedback.User = user;
            return PartialView(feedback);
        }

        [HttpGet]
        public ActionResult Create(Guid authorId, Guid recieverId)
        {
            return PartialView(new FeedbackForm
            {
                AuthorId = DataAccessLayer.Get<UserBase>().First().Id,
                RecieverId = recieverId,
            });
        }

        [HttpPost]
        public ActionResult Create(FeedbackForm model)
        {
            var reciever = DataAccessLayer.GetById<UserBase>(model.RecieverId);
            DataAccessLayer.Create(new Review
            {
                AuthorId = model.AuthorId,
                RecieverId = model.RecieverId,
                Rating = model.Rating,
                CreationDate = DateTime.UtcNow,
                ModifyDate = DateTime.UtcNow,
                Text = model.Text,
                Title = model.Title
            });
            DataAccessLayer.DbContext.SaveChanges();
            return new RedirectResult(string.Format("/{0}/Detail/{1}", reciever.ControllerNameByUser(), reciever.Id));
        }
    }
}
