﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Browsing : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime When { get; set; }
        [Required]
        public virtual UserBase Who { get; set; }
        [Required]
        public virtual UserBase What { get; set; }
    }
}