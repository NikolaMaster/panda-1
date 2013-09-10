using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class ChecklistType : IGuidIdentifiable, ICodeIdentifiable
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public ChecklistType()
        {
            Id = Guid.NewGuid();
        }
    }
}
