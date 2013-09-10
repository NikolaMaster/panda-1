using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Review : IGuidIdentifiable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<UserBase> Users { get; set; }

        public Review() 
        {
            Id = Guid.NewGuid();
            if (Users == null)
                Users = new List<UserBase>();
        }
    }
}
