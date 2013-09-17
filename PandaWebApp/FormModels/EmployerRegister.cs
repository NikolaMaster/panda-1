using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public abstract class EmployerRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Register.CustomPasswordLength]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string PasswordConfirmation { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength()]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Phone { get; set; }

        public abstract string EmployerType { get; }
    }

    public class CompanyRegister : EmployerRegister
    {
        [Required]
        public string EmployerName { get; set; }
        [Required]
        public string CompanyType { get; set; }

        public string CompanySubType { get; set; }


        public override string EmployerType
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class PrivateEmployerRegister : EmployerRegister
    {
        public override string EmployerType
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class PrivateRecruiterRegister : EmployerRegister
    {
        public override string EmployerType
        {
            get { throw new NotImplementedException(); }
        }
    }
}