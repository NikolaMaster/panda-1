using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;

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
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(Review source, Feedback.Entry dest)
        {
            dest.Id = source.Id;
            dest.Text = source.Text;
            dest.Title = source.Title;
            dest.Rating = source.Rating;
            dest.SendDate = source.CreationDate;
            dest.AuthorName = DataAccessLayer.GetUserName(source.Author);
            dest.AuthorPhoto = source.Author.Avatar == null ? string.Empty : source.Author.Avatar.SourceUrl;
        }
    }
}