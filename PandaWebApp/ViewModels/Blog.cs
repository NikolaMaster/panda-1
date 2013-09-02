using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.Engine;

namespace PandaWebApp.ViewModels
{
    public class Blog
    {
        public class Entry
        {
            public string Title { get; set; }
            public string Image { get; set; }
            public string ShortText 
            {
                get
                {
                    if (FullText == null)
                    {
#if RELEASE
                        return string.Empty;
#endif
#if DEBUG
                        throw new ArgumentNullException("FullText");
#endif
                    }
                    return FullText.Shorten(200);
                }
            }
            public string FullText { get; set; }

            public DateTime CreatedDate { get; set; }

            public DateTime ModifyDate { get; set; }

            public Guid Id { get; set; }
        }

        public int Count;
        public ICollection<Blog> Posts; 
        public string Title { get; set; }
    }
}