using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Attrib : IGuidIdentifiable, ICodeIdentifiable
    {
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        public int Weight { get; set; }
        public virtual AttribType AttribType { get; set; }

        public Attrib()
        {
            Id = Guid.NewGuid();
        }
    }
}
