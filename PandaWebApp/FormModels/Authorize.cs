using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PandaWebApp.Engine;

namespace PandaWebApp.FormModels
{
    public class Login
    {
        [Required, EmailAddress, Display(Name = "Введите Email")]
        public string Email { get; set; }

        [Required, CustomPasswordLength, Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}