﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class StaticPageUnit : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public virtual MvcAction MvcAction { get; set; }
        public string Content { get; set; }

        public StaticPageUnit()
        {
            Id = Guid.NewGuid();
        }
    }
}
