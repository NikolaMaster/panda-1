using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class FeedbackToReview : BaseDataAccessLayerBinder<Feedback.Entry, Review>
    {

        public FeedbackToReview(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

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
            dest.UserName = DataAccessLayer.GetUserName(user);
            dest.UserPhoto = user.Avatar == null ? string.Empty : user.Avatar.SourceUrl;            
        }
    }
}