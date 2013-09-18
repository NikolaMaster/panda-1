using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;

namespace PandaWebApp.FormModels
{
    public class PromouterRegister
    {
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, CustomPasswordLength, Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required, Compare("Password"), Display(Name = "Подтверждение пароля")]
        public string PasswordConfirmation { get; set; }
    }
}