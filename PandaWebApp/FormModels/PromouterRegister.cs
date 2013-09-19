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
        [Required(ErrorMessage = "Email: не заполнено!"), EmailAddress(ErrorMessage = "Email: некорректный"), Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль: не заполнено!"), CustomPasswordLength, Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтверждение пароля: не заполнено!"), Compare("Password", ErrorMessage = "Пароли не совпадают!"), Display(Name = "Подтверждение пароля")]
        public string PasswordConfirmation { get; set; }
    }
}