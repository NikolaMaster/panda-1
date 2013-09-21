﻿using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;
using System;

namespace PandaWebApp.Engine.Binders
{
    public class ViewEmployerSearchViewToChecklist : BaseDataAccessLayerBinder<EmployerSearchView, Checklist>
    {
        public ViewEmployerSearchViewToChecklist(DataAccessLayer dataAccessLayer)
            : base(dataAccessLayer)
        {
        }

        public override void Load(EmployerSearchView source, Checklist dest)
        {
            throw new Exception("Only view bind allowed");
        }

        public override void InverseLoad(Checklist source, EmployerSearchView dest)
        {
            ValueFromAttributeConverter.ModelFromAttributes(dest, source.AttrbuteValues, DataAccessLayer);
            dest.Checklist = source;
            if (dest.Start.HasValue && dest.End.HasValue)
                dest.Days = (int) ((dest.End.Value - dest.Start.Value).TotalDays);
            dest.DaysOnSite = (int) (DateTime.UtcNow - source.CreationDate).TotalDays;
            dest.AvatarUrl = source.User.Avatar.SourceUrl;
        }
    }
}