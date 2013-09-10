using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class SeoEntry : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }

        public virtual ICollection<MvcAction> MvcActions { get; set; }
        public virtual ICollection<UserBase> Users { get; set; }

        public SeoEntry()
        {
            Id = Guid.NewGuid();
            if (MvcActions == null)
                MvcActions = new List<MvcAction>();
            if (Users == null)
                Users = new List<UserBase>();
        }
    }
}
