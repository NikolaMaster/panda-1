using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public interface IPaginators
    {
        PagerFormModel Pager { get; set; }
    }
}