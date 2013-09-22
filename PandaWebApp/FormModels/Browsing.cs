using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PandaWebApp.FormModels
{
    public class Browsing
    {
        public const int Days = 14;

        public DateTime Prev { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public class ValueItem
        {
            public string UserName { get; set; }
            public string UserController { get; set; }
            public DateTime When { get; set; }
        }

        public Dictionary<DateTime, IEnumerable<ValueItem>> Values { get; set; }

        public string JsonValues { get; set; }
    }
}