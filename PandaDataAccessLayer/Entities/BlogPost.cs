using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class BlogPost : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string FullText { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        
        public virtual Photo Picture { get; set; }
        public virtual SeoEntry SeoEntry { get; set; }

        public BlogPost()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            ModifyDate = DateTime.UtcNow;
        }
    }
}
