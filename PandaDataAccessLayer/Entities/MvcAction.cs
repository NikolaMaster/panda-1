using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class MvcAction : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        
        public string Controller { get; set; }
        public string Action { get; set; }

        public virtual SeoEntry SeoEntry { get; set; }

        public MvcAction()
        {
            Id = Guid.NewGuid();
        }
    }
}
