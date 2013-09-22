using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.FormModels
{
    public class SupportForm
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Text { get; set; }

        public string SuccessMessage { get; set; }
    }
}
