using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class DictGroup : IGuidIdentifiable, ICodeIdentifiable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DictValue> DictValues { get; set; }

        public DictGroup() 
        {
            if (DictValues == null)
                DictValues = new List<DictValue>();
        }
    }
}
