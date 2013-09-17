﻿using System;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormFeedbackToReview : BaseBinder<FeedbackForm, Review>
    {

        public override void Load(FeedbackForm source, Review dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(Review source, FeedbackForm dest)
        {
            dest.AuthorId = source.Author.Id;
            dest.RecieverId = source.Reciever.Id;
            dest.Rating = source.Rating;
            dest.Text = source.Text;
            dest.Title = source.Title;
        }
    }
}