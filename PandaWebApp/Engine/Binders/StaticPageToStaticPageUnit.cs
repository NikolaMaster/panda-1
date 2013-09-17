using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{

    public class StaticPageToStaticPageUnit : BaseBinder<StaticPage, StaticPageUnit>
    {
        public override void Load(StaticPage source, StaticPageUnit dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(StaticPageUnit source, StaticPage dest)
        {
            dest.Id = source.Id.ToString();
            dest.Content = source.Content;
            dest.Code = source.Code;
        }
    }
}