using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Attrib2ChecklistType : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public Attrib Attribute { get; set; }
        public ChecklistType ChecklistType { get; set; }

        public Attrib2ChecklistType()
        {
            Id = Guid.NewGuid();
        }
    }
}
