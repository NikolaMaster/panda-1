﻿using PandaDataAccessLayer.Entities;
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
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<PrivateEmployer> PrivateEmployers { get; set; }
        public DbSet<PrivateRecruiter> PrivateRecruiters { get; set; }
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

        public DbSet<WorkExpirience> WorkExpirience { get; set; }
        public DbSet<EntityList> EntityLists { get; set; }

        public DbSet<SeoEntry> SeoEntries { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBase>().ToTable("UserBase");
            modelBuilder.Entity<EmployerUser>().ToTable("EmployerUser");
            modelBuilder.Entity<CompanyMember>().ToTable("CompanyMember");
            modelBuilder.Entity<PrivateEmployer>().ToTable("PrivateEmployer");
            modelBuilder.Entity<PrivateRecruiter>().ToTable("PrivateRecruiter");
            modelBuilder.Entity<PromouterUser>().ToTable("PromouterUser");    
        /*
            //users mapping
            modelBuilder.Entity<CompanyMember>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CompanyMember");
            });
            modelBuilder.Entity<PrivateEmployer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PrivateEmployer");
            });
            modelBuilder.Entity<PrivateRecruiter>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PrivateRecruiter");
            });
            modelBuilder.Entity<PromouterUser>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PromouterUser");
            });*/
            //checklist mapping
        }
    }
}
