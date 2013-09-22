using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string UserController { get; set; }
        public int FavoritesCount { get; set; }
        public int Coins { get; set; }
    }
}