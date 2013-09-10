using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class DesiredWork : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public virtual DictValue Work { get; set; }
        public virtual EntityList EntityList { get; set; }

        public DesiredWork()
        {
            Id = Guid.NewGuid();
        }
    }
}
