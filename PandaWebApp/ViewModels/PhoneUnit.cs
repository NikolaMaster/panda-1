using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.ViewModels
{
    public class PhoneUnit
    {
        public string CountryCode { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", CountryCode, Code, Number);
        }
    }

}