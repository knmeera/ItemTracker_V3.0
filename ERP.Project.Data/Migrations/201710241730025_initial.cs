namespace ERP.Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        ColorCode = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.TrackerItem",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ItemSummary = c.String(),
                        ItemCreatedDate = c.String(),
                        AssignedDate = c.String(),
                        ItemEndDate = c.String(),
                        WorkCompleted = c.String(),
                        CreatedBy = c.String(),
                        Owner = c.String(),
                        Impact = c.String(),
                        Resolution = c.String(),
                        ResolvedDate = c.String(),
                        AttachmentPath = c.String(),
                        ParentId = c.Int(nullable: false),
                        AssignedTo = c.String(),
                        Subjet = c.String(),
                        ItemProjectId = c.Int(nullable: false),
                        ItemCategoryId = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        ItemPriorityId = c.Int(nullable: false),
                        ItemStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ItemPriority", t => t.ItemPriorityId, cascadeDelete: true)
                .ForeignKey("dbo.itemStatus", t => t.ItemStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ItemType", t => t.ItemTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ItemProjectId, cascadeDelete: true)
                .Index(t => t.ItemProjectId)
                .Index(t => t.ItemCategoryId)
                .Index(t => t.ItemTypeId)
                .Index(t => t.ItemPriorityId)
                .Index(t => t.ItemStatusId);
            
            CreateTable(
                "dbo.ItemPriority",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        PriorityName = c.String(nullable: false, maxLength: 100),
                        ColorCode = c.String(),
                    })
                .PrimaryKey(t => t.PriorityId);
            
            CreateTable(
                "dbo.itemStatus",
                c => new
                    {
                        ItemStatusId = c.Int(nullable: false, identity: true),
                        ItemStatusName = c.String(nullable: false, maxLength: 100),
                        ColorCode = c.String(),
                    })
                .PrimaryKey(t => t.ItemStatusId);
            
            CreateTable(
                "dbo.ItemType",
                c => new
                    {
                        ItemTypeId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 100),
                        ColorCode = c.String(),
                    })
                .PrimaryKey(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        RegId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(),
                        SurName = c.String(),
                        Gender = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                        EmailId = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RegId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "RoleId", "dbo.Role");
            DropForeignKey("dbo.TrackerItem", "ItemProjectId", "dbo.Project");
            DropForeignKey("dbo.TrackerItem", "ItemTypeId", "dbo.ItemType");
            DropForeignKey("dbo.TrackerItem", "ItemStatusId", "dbo.itemStatus");
            DropForeignKey("dbo.TrackerItem", "ItemPriorityId", "dbo.ItemPriority");
            DropForeignKey("dbo.TrackerItem", "ItemCategoryId", "dbo.ItemCategory");
            DropIndex("dbo.Members", new[] { "RoleId" });
            DropIndex("dbo.TrackerItem", new[] { "ItemStatusId" });
            DropIndex("dbo.TrackerItem", new[] { "ItemPriorityId" });
            DropIndex("dbo.TrackerItem", new[] { "ItemTypeId" });
            DropIndex("dbo.TrackerItem", new[] { "ItemCategoryId" });
            DropIndex("dbo.TrackerItem", new[] { "ItemProjectId" });
            DropTable("dbo.Role");
            DropTable("dbo.Members");
            DropTable("dbo.Admin");
            DropTable("dbo.Project");
            DropTable("dbo.ItemType");
            DropTable("dbo.itemStatus");
            DropTable("dbo.ItemPriority");
            DropTable("dbo.TrackerItem");
            DropTable("dbo.ItemCategory");
        }
    }
}
