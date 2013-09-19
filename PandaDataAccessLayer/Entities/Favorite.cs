using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Favorite : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public virtual UserBase Owner { get; set; }

        public virtual UserBase Like { get; set; }

        public Favorite()
        {
            Id = Guid.NewGuid();
        }
    }
}
