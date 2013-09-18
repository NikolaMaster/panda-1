using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.ViewModels
{
    public class StaticPage
    {
        public struct SeoEntryUnit
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Keyword { get; set; }
        }

        public struct MvcActionUnit
        {
            public string Controller { get; set; }
            public string Action { get; set; }
        }

        public Guid Id { get; set; }
        public string Content { get; set; }
        public SeoEntryUnit SeoEntry { get; set; }
        public MvcActionUnit MvcAction { get; set; }

    }
}