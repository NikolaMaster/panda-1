using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{

    public class StaticPageToStaticPageUnit : BaseDataAccessLayerBinder<StaticPage, StaticPageUnit>
    {
        
        public StaticPageToStaticPageUnit(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(StaticPage source, StaticPageUnit dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(StaticPageUnit source, StaticPage dest)
        {
            dest.Content = source.Content;
            dest.Id = source.Id;
            
            var seoEntry =
                    DataAccessLayer.Get<SeoEntry>(x => x.Id == source.MvcAction.SeoEntry.Id).FirstOrDefault();

            if (seoEntry != null)
            {
                dest.SeoEntry = new StaticPage.SeoEntryUnit()
                    {
                        Id = seoEntry.Id,
                        Title = seoEntry.Title,
                        Keyword = seoEntry.Keyword,
                        Description = seoEntry.Description,
                    };
            }

            dest.MvcAction = new StaticPage.MvcActionUnit()
                {
                    Action = source.MvcAction.Action,
                    Controller = source.MvcAction.Controller
                }; 
        }
    }
}