using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class FavoriteViewModel
    {
        public class Item
        {
            public string UserName { get; set; }
            public string Controller { get; set; }
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
        }

        public IEnumerable<Item> Items { get; set; }
    }
}