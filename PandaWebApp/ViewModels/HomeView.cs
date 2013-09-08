using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class HomeView
    {
        public int TotalPromouters { get; set; }
        public int TotalEmployers { get; set; }
        public double AveragePromouterCost { get; set; }
        public double AverageEmployerCost { get; set; }
        public IEnumerable<Promouter> TopPromouters { get; set; }
        public IEnumerable<Employer> TopEmployers { get; set; }
    }
}