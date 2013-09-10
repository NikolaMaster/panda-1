using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class DesiredWorkTime : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DayOfWeek { get; set; }

        public virtual EntityList EntityList { get; set; }

        public DesiredWorkTime()
        {
            Id = Guid.NewGuid();
        }
    }
}
