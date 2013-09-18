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
}