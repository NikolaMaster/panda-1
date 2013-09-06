using PandaDataAccessLayer.DAL;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaWebApp.Engine;

namespace PandaWebApp.FormModels
{
    public class PromouterForm : Promouter
    {
        public IEnumerable<SelectListItem> EducationValues { get; set; }
        public IEnumerable<SelectListItem> SalaryValues { get; set; }

        public PromouterForm(DataAccessLayer dataAccessLayer)
        {
            EducationValues = dataAccessLayer.ListItemsFromDict(Constants.EducationCode);
            SalaryValues = dataAccessLayer.ListItemsFromDict(Constants.SalaryCode)
                .OrderBy(x => string.IsNullOrEmpty(x.Text) ? -1 : int.Parse(x.Text))
                .ToList();
        }
    }
}