using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public  class PhoneNumber : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public DictValue CountryCode { get; set; }

        public string Code { get; set; }
        public string Number { get; set; }

        public virtual EntityList EntityList { get; set; }

        public PhoneNumber()
        {
            Id = Guid.NewGuid();
        }
    }
}
