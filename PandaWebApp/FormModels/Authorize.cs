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
        [Required(ErrorMessage = "Email: не заполнено!"), EmailAddress(ErrorMessage = "Email: некорректный"), Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль: не заполнено!"), CustomPasswordLength, Display(Name = "Пароль")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}