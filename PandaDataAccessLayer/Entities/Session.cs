using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Session : IGuidIdentifiable
    {
        public Guid Id { get;set; }

        public DateTime LastHit { get; set; }

        public virtual UserBase User { get; set; }

        public Session()
        {
            Id = Guid.NewGuid();
        }
    }
}
