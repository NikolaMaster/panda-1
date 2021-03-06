﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Binders
{
    public class FormPromouterSearchToSearchValues : BaseDataAccessLayerBinder<PromouterSearchForm, Dictionary<Attrib, object>>
    {
        public FormPromouterSearchToSearchValues(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(PromouterSearchForm source, Dictionary<Attrib, object> dest)
        {
            dest.Add(DataAccessLayer.Constants.City, source.City);
            dest.Add(DataAccessLayer.Constants.Gender, source.Gender);
            dest.Add(DataAccessLayer.Constants.Salary, source.Salary);
        }

        public override void InverseLoad(Dictionary<Attrib, object> source, PromouterSearchForm dest)
        {
            throw new NotImplementedException();
        }
    }
}