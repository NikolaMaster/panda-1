using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class PagerFormModel
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
    }
}