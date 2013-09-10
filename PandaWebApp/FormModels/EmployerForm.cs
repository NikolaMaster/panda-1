using PandaDataAccessLayer.DAL;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class EmployerForm
    {
        public Guid UserId { get; set; }
        public string Icon { get; set; }
        public string EmployerName { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public int DaysOnSite { get; set; }
        public bool AccountConfirmed { get; set; }
    }
}