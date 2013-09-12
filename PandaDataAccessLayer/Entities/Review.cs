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
        public Guid RecieverId { get; set; }
        public Guid AuthorId { get; set; }

        //public virtual ICollection<UserBase> Users { get; set; }
        [ForeignKey("RecieverId")]
        public virtual UserBase Reciever { get; set; }
        [ForeignKey("AuthorId")]
        public virtual UserBase Author { get; set; }

        public Review() 
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            ModifyDate = DateTime.UtcNow;
        }
    }
}
