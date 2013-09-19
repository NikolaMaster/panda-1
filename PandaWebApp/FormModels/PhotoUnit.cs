using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class PhotoUnit
    {
        public Guid Id { get; set; }
        public HttpPostedFileBase File { get; set; }
    }

}