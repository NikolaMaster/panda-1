using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine
{
    public class CustomPasswordLength : MaxLengthAttribute
    {
        public const int MaxPasswordLength = 10;
        public CustomPasswordLength()
            : base(MaxPasswordLength)
        {
            ErrorMessage = "Длина пароля не может быть более " +
                MaxPasswordLength + " символов";
        }
    }

    public class CustomValidator : IValidatableObject
    {
        [Display(Name = "Email")]
        public virtual string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(this.Email))
            {
                errors.Add(new ValidationResult("Введите название книги"));
            }

            return errors;
        }
    }

}