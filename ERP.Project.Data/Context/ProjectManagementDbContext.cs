using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ERP.Project.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Project.Data.Context
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext() : base("Name=MSSqlCon")//this is the connection string name
        {
        }
        

        public DbSet<TrackerItem> TrackerItems { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<ItemPriority> ItemPriorities { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new TrackerItemConfig());
            modelBuilder.Configurations.Add(new ItemCategoryConfig());   
            modelBuilder.Configurations.Add(new ItemTypeConfig());
            modelBuilder.Configurations.Add(new ItemStatusConfig());
            modelBuilder.Configurations.Add(new ItemPriorityConfig());
            modelBuilder.Configurations.Add(new ProjectConfig());
            modelBuilder.Configurations.Add(new RegistrationConfig());
            modelBuilder.Configurations.Add(new RolesConfig());
            modelBuilder.Configurations.Add(new LoginConfig());


        }
        public class TrackerItemConfig : EntityTypeConfiguration<TrackerItem>
        {
            public TrackerItemConfig()
            {   //primary key
                HasKey(m => m.ItemId);
                //for Identity(AutoGenerate ID Values in Database Table
                Property(t => t.ItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                //table name in db
                ToTable("TrackerItem");

                //forien key  Adding
                //TracerItem Model req ItemCategory
                HasRequired<ItemCategory>(s => s.ItemCategory)
                .WithMany(g => g.TrackerItems)
                .HasForeignKey<int>(s => s.ItemCategoryId);


                HasRequired<ItemStatus>(s => s.ItemStatus)
                 .WithMany(g => g.TrackerItems)
                 .HasForeignKey<int>(s => s.ItemStatusId);


                HasRequired<ItemType>(s => s.ItemType)
                 .WithMany(g => g.TrackerItems)
                 .HasForeignKey<int>(s => s.ItemTypeId);

                HasRequired<ItemPriority>(s => s.ItemPriority)
                 .WithMany(g => g.TrackerItems)
                 .HasForeignKey<int>(s => s.ItemPriorityId);

                HasRequired<project>(s => s.project)
                    .WithMany(g => g.TrackerItems)
                    .HasForeignKey<int>(s => s.ItemProjectId);
            }
        }
        public class ItemCategoryConfig : EntityTypeConfiguration<ItemCategory>
        {
            public ItemCategoryConfig()
            {
                this.HasKey(t => t.CategoryId);
                Property(t => t.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.CategoryName).IsRequired().HasMaxLength(100);

                ToTable("ItemCategory");
            }
        }
        public class ItemTypeConfig : EntityTypeConfiguration<ItemType>
        {
            public ItemTypeConfig()
            {
                this.HasKey(t => t.ItemTypeId);
                Property(t => t.ItemTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.ItemName).IsRequired().HasMaxLength(100);

                ToTable("ItemType");
            }
        }
        public class ItemPriorityConfig : EntityTypeConfiguration<ItemPriority>
        {
            public ItemPriorityConfig()
            {
                this.HasKey(t => t.PriorityId);
                Property(t => t.PriorityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.PriorityName).IsRequired().HasMaxLength(100);

                ToTable("ItemPriority");
            }
        }
        public class ItemStatusConfig : EntityTypeConfiguration<ItemStatus>
        {
            public ItemStatusConfig()
            {
                HasKey(t => t.ItemStatusId);
                Property(t => t.ItemStatusId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.ItemStatusName).IsRequired().HasMaxLength(100);

                ToTable("itemStatus");
            }
        }

        //public System.Data.Entity.DbSet<ClassDemo.Models.Project> Projects { get; set; }
        public class ProjectConfig : EntityTypeConfiguration<project>
        {
            public ProjectConfig()
            {
                this.HasKey(t => t.ProjectId);
                Property(t => t.ProjectId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.ProjectName).IsRequired().HasMaxLength(100);

                ToTable("Project");
            }
        }
        
        public class RegistrationConfig : EntityTypeConfiguration<Member>
        {
            public RegistrationConfig()
            {
                this.HasKey(t => t.RegId);
                Property(t => t.RegId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(t => t.EmailId).IsRequired().HasMaxLength(100);
                Property(t => t.Password).IsRequired().HasMaxLength(100);
                Property(t => t.UserName).IsRequired().HasMaxLength(100);
                ToTable("Members");

                HasRequired<Role>(s => s.Role)
                    .WithMany(g => g.Members)
                    .HasForeignKey<int>(s => s.RoleId);
            }

        }
        public class RolesConfig: EntityTypeConfiguration<Role>
        {
            public RolesConfig()
            {
                this.HasKey(t => t.RoleId);
                Property(t => t.RoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                ToTable("Role");
            }
        }
        public class LoginConfig:EntityTypeConfiguration<Login>
        {
            public LoginConfig()
            {
                this.HasKey(t => t.Id);
                Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                ToTable("Admin");
            }
        }
        
    }
}