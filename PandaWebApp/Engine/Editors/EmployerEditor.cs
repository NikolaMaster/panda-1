﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Engine.Editors
{

    public class EmployerEditor
    {
        public IEnumerable<Attrib> Attributes { get; private set; }

        public EmployerEditor(IEnumerable<Attrib> attributes)
        {
            Attributes = attributes;
        }

        public void Edit(Employer source, PromouterUser dest)
        {
            //source.Email = dest.Email;

            var checklist = dest.Checklists.FirstOrDefault();
            if (checklist == null)
            {
#if DEBUG
                throw new HttpException(404, "Checklist not found");
#endif
#if RELEASE
                return;
#endif
            }

            checklist.AttrbuteValues.Clear();

            foreach (var attribute in Attributes)
            {
                var attributeValue = new AttribValue
                {
                    AttribId = attribute.Id,
                    ChecklistId = checklist.Id
                };
                
                checklist.AttrbuteValues.Add(attributeValue);
            }
        }
    }
}