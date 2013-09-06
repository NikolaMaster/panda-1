using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class PandaPulse
    {
        public class Entry
        {
            public string Image;
            public string Name;
        }

        public int Online { get; set; }

        public IEnumerable<Entry> Items { get; set; }
    }
}