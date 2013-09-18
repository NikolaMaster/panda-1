using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Pulse : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public DictValue Operation { get; set; }
        public DateTime OperationDate { get; set; }
        [ForeignKey("UserId")]
        public UserBase UserBase { get; set; }
        public Guid UserId { get; set; }

        public Pulse()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.UtcNow;
        }
    }
}
