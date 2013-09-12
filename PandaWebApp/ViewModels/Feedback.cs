using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class Feedback
    {
        public class Entry
        {
            public string Title { get; set; }
            public string AuthorPhoto { get; set; }
            public string AuthorName { get; set; }
            public string Text { get; set; }
            public int Rating { get; set; }
            public DateTime SendDate { get; set; }
        }

        public UserBase User { get; set; }
        public int Count { get; set; }
        public ICollection<Entry> Entries { get; set; }
        public Feedback() 
        {
            Entries = new List<Entry>();
        }
    }
}