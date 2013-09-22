using System;
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

        public DateTime When { get; set; }
        public virtual UserBase Who { get; set; }
        public virtual UserBase What { get; set; }

        public Browsing()
        {
            Id = Guid.NewGuid();
        }
    }
}
