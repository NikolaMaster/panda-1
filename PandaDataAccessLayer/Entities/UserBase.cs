using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaDataAccessLayer.Entities
{
    public abstract class UserBase : IGuidIdentifiable
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public int Coins { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual SeoEntry SeoEntry { get; set; }
        public virtual Photo Avatar { get; set; }
        public virtual IEnumerable<Pulse> Pulse { get; set; }

        public virtual ICollection<Checklist> Checklists { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public abstract Checklist MainChecklist
        {
            get;
        }

        protected UserBase() 
        {
            Id = Guid.NewGuid();
            IsAdmin = false; 
            if (Checklists == null)
                Checklists = new List<Checklist>();
            if (Sessions == null)
                Sessions = new List<Session>();
            if (Albums == null)
                Albums = new List<Album>();

            CreationDate = DateTime.UtcNow;
            IsConfirmed = false;
        }
    }
}
