using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PandaDataAccessLayer
{
    public class MainDbContext : DbContext
    {
        //Users
        public DbSet<UserBase> Users { get; set; }
        public DbSet<EmployerUser> EmployerUsers { get; set; }
        public DbSet<PromouterUser> PromouterUsers { get; set; }
        //Checklists
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistType> ChecklistTypes { get; set; }
        //Attributes
        public DbSet<Attrib> Attribs { get; set; }
        public DbSet<AttribType> AttribTypes { get; set; }
        public DbSet<AttribValue> AttribValues { get; set; }
        public DbSet<Attrib2ChecklistType> Attrib2ChecklistType { get; set; }
        //Dict
        public DbSet<DictGroup> DictGroups { get; set; }
        public DbSet<DictValue> DictValues { get; set; }
        //Work expirience
        public DbSet<WorkExpirience> WorkExpirience { get; set; }
        public DbSet<EntityList> EntityLists { get; set; }
        //Seo
        public DbSet<SeoEntry> SeoEntries { get; set; }
        public DbSet<Session> Sessions { get; set; }
        //Photos
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        //Blog
        public DbSet<BlogPost> BlogPosts { get; set; }
        //Reviews
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DesiredWork> DesiredWork { get; set; }
        public DbSet<DesiredWorkTime> DesiredWorkTime { get; set; }
        //Static page
        public DbSet<StaticPageUnit> StaticPageUnit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBase>().ToTable("UserBase");
            modelBuilder.Entity<EmployerUser>().ToTable("EmployerUser");
            modelBuilder.Entity<PromouterUser>().ToTable("PromouterUser");
           
            modelBuilder.Entity<Review>()
                        .HasRequired(a => a.Reciever)
                        .WithMany()
                        .HasForeignKey(u => u.RecieverId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Review>()
                        .HasRequired(a => a.Author)
                        .WithMany()
                        .HasForeignKey(u => u.AuthorId)
                        .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
