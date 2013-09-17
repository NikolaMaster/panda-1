﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class Register
    {
        public class Delegate
        {
            public class DelegateType
            {
                public string Title { get; set; }
                public Guid Id { get; set; }
            }

            public string Name { get; set; }
            public string EmployerType { get; set; }
            public string About { get; set; }
            public string Surname { get; set; }
            public string Position { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PasswordConfirmation { get; set; }

            public DelegateType Type { get; set; }
            
        }

        public class CustomPasswordLength : MaxLengthAttribute
        {
            public const int MaxPasswordLength = 10;
            public CustomPasswordLength()
                : base(MaxPasswordLength)
            {
                this.ErrorMessage = "Длина пароля не может быть более " + 
                    MaxPasswordLength + " символов";
            }
        }

        public class Promouter
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [CustomPasswordLength]
            public string Password { get; set; }
            [Required]
            [Compare("Password")]
            public string PasswordConfirmation { get; set; }

            public Guid Id { get; set; }
        }


        public class Employer
        {
            [Required, EmailAddress]
            public string Email { get; set; }
            [Required, CustomPasswordLength]
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
            public string Phone { get; set; }


            public Guid Id { get; set; }
        }
    }
}