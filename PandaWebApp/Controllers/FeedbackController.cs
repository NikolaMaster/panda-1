using System.Collections.ObjectModel;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Filters;
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

        [NonAction]
        private Feedback prepareFeedbacks(IEnumerable<Review> feedbacks, int count = 0)
        {
            var binder = new FeedbackToReview(DataAccessLayer);
            var feedbacksArray = feedbacks as Review[] ?? feedbacks.ToArray();
            var collection = count > 0 ? feedbacksArray.Take(count) : feedbacksArray;
            return new Feedback
            {
                RedAverage = feedbacksArray.RedAverage(),
                OrangeAverage = feedbacksArray.OrangeAverage(),
                GreenAverage = feedbacksArray.GreenAverage(),
                Count = feedbacksArray.Length,
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
            var user = DataAccessLayer.GetById<UserBase>(userId);
            feedback.User = user;
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
            feedback.User = user;
            return PartialView(feedback);
        }


        public ActionResult TopDialogFeedback()
        {
            var totalFeedback = DataAccessLayer.Get<Review>();
            
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

            var tuple = new Tuple<ICollection<Feedback.Entry>, int>(list,totalFeedback.Count());
        
            return PartialView(tuple);

        }

        public ActionResult TopUserFeedback(Guid userId)
        {
            var user = DataAccessLayer.GetById<UserBase>(userId);
            var feedback = prepareFeedbacks(DataAccessLayer.Get<Review>(x => x.RecieverId == userId), UserFeedbacksCount);
            feedback.User = user;
            return PartialView(feedback);
        }

        [HttpGet]
        [BaseAuthorizationReuired]
        public ActionResult Create(Guid authorId, Guid recieverId)
        {
            return PartialView(new FeedbackForm
            {
                AuthorId = DataAccessLayer.Get<UserBase>().First().Id,
                RecieverId = recieverId,
            });
        }

        [HttpPost]
        [BaseAuthorizationReuired]
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

        [AdministratorAuthorizationRequired]
        public ActionResult Delete(Guid id)
        {
            DataAccessLayer.DeleteById<Review>(id);
            DataAccessLayer.DbContext.SaveChanges();
            return new RedirectResult(Request.UrlReferrer.ToString());
        }
    }
}
