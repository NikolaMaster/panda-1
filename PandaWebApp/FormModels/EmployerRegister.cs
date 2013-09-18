using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaWebApp.Engine;
using PandaWebApp.Engine.Binders;
using PandaWebApp.ViewModels;

namespace PandaWebApp.FormModels
{
    public abstract class EmployerRegister
    {
        [ValueFrom(Constants.EmailCode), Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, CustomPasswordLength, Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required, Compare("Password"), Display(Name = "Подтверждение пароля")]
        public string PasswordConfirmation { get; set; }

        [ValueFrom(Constants.CityCode), Required, Display(Name = "Город")]
        public string City { get; set; }
        [ValueFrom(Constants.FirstNameCode), Required, Display(Name = "Имя")]
        public string FirstName { get; set; }
        [ValueFrom(Constants.LastNameCode), Required, Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [ValueFrom(Constants.JobTitleCode), Required, Display(Name = "Должность")]
        public string JobTitle { get; set; }
        [Required, Display(Name = "Телефон")]
        public PhoneUnit Phone { get; set; }

        [ValueFrom(Constants.EmployerTypeCode)]
        public abstract string EmployerType { get; }
    }

    public class CompanyRegister : EmployerRegister
    {
        [ValueFrom(Constants.EmployerNameCode), Required, Display(Name = "Название компании")]
        public string EmployerName { get; set; }

        [ValueFrom(Constants.CompanyTypeCode), Required]
        public string CompanyType { get; set; }

        [ValueFrom(Constants.CompanySubTypeCode), Display(Name = "Тип компании")]
        public string CompanySubType { get; set; }

        [ValueFrom(Constants.EmployerTypeCode), ScaffoldColumn(true)]
        public override string EmployerType
        {
            get { return Constants.CompanyRepresenter; }
        }
    }

    public class PrivateEmployerRegister : EmployerRegister
    {
        [ValueFrom(Constants.EmployerTypeCode), ScaffoldColumn(true)]
        public override string EmployerType
        {
            get { return Constants.PrivateEmployer; }
        }
    }

    public class PrivateRecruiterRegister : EmployerRegister
    {
        [ValueFrom(Constants.EmployerTypeCode), ScaffoldColumn(true)]
        public override string EmployerType
        {
            get { return Constants.PrivateRecruiter; }
        }
    }
}