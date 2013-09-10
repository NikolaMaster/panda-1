using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class EntityList : IGuidIdentifiable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public virtual ICollection<WorkExpirience> WorkExpirience { get; set; }
        public virtual ICollection<DesiredWork> DesiredWork { get; set; }
        public virtual ICollection<DesiredWorkTime> DesiredWorkTime { get; set; }

        public EntityList() 
        {
            Id = Guid.NewGuid();
            if (WorkExpirience == null)
                WorkExpirience = new List<WorkExpirience>();
            if (DesiredWork == null)
                DesiredWork = new List<DesiredWork>();
            if (DesiredWorkTime == null)
                DesiredWorkTime = new List<DesiredWorkTime>();
        }
    }
}
