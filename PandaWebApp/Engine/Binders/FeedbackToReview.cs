using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class FeedbackToReview : BaseBinder<Feedback.Entry, Review>
    {

        public override void Load(Feedback.Entry source, Review dest)
        {
            throw new NotImplementedException();
        }

        public override void InverseLoad(Review source, Feedback.Entry dest)
        {
            var user = source.Users.First();
            dest.Text = source.Text;
            dest.Title = source.Title;
            dest.Rating = source.Rating;
            dest.SendDate = source.CreationDate;
            dest.UserName = user.FirstName;
            dest.UserPhoto = user.Avatar == null ? string.Empty : user.Avatar.SourceUrl;            
        }
    }
}