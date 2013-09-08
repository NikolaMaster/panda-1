using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class WorkExpirience : IGuidIdentifiable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime? Start { get; set; }
        //null means in present time
        public DateTime? End { get; set; }
        public string Title { get; set; }
        public int Hours { get; set; }
        public string WorkName { get; set; }

        public virtual EntityList EntityList { get; set; }
    }

}
