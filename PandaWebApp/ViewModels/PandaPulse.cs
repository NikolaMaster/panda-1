using PandaDataAccessLayer.Entities;
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
            public string Image { get; set; }
            public string Name { get; set; }
            public string Operation { get; set; }
            public UserBase User { get; set; }
        }

        public int Online { get; set; }

        public IEnumerable<Entry> Items { get; set; }
    }
}