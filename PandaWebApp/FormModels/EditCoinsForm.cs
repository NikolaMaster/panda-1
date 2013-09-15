using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class EditCoinsForm
    {
        public Guid UserId { get; set; }
        public int Coins{ get; set; }
    }
}