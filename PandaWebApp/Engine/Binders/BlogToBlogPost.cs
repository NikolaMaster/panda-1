using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class BlogToBlogPost : BaseBinder<Blog.Entry, BlogPost>
    {
        public DataAccessLayer DataAccessLayer { get; private set; }

        public BlogToBlogPost(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }

        public override void Load(Blog.Entry source, BlogPost dest)
        {
            dest.Title = source.Title;
            dest.FullText = source.FullText;
            dest.Picture = new Photo() {SourceUrl = source.Image};
            dest.CreationDate = source.CreatedDate;
            dest.ModifyDate = source.ModifyDate;
            //dest.Id = source.Id;
        }

        public override void InverseLoad(BlogPost source, Blog.Entry dest)
        {
            dest.Title = source.Title;
            dest.FullText = source.FullText;
            dest.Image = source.Picture == null ? string.Empty : source.Picture.SourceUrl;
            dest.CreatedDate = source.CreationDate;
            dest.ModifyDate = source.ModifyDate;
            dest.Id = source.Id;
        }
    }
}