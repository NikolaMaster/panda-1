using System;
using System.Collections.Generic;
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
        public UserBase User { get; set; }

        public Pulse()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.UtcNow;
        }
    }
}
