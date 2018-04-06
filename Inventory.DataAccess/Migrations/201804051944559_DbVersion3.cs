namespace Inventory.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbVersion3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "PermissionGroup_PermissionGroupId", "dbo.PermissionGroups");
            DropIndex("dbo.Permissions", new[] { "PermissionGroup_PermissionGroupId" });
            RenameColumn(table: "dbo.Permissions", name: "PermissionGroup_PermissionGroupId", newName: "PermissionGroupId");
            AddColumn("dbo.PermissionGroups", "PermissionGroupName", c => c.String());
            AlterColumn("dbo.Permissions", "PermissionGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Permissions", "PermissionGroupId");
            AddForeignKey("dbo.Permissions", "PermissionGroupId", "dbo.PermissionGroups", "PermissionGroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "PermissionGroupId", "dbo.PermissionGroups");
            DropIndex("dbo.Permissions", new[] { "PermissionGroupId" });
            AlterColumn("dbo.Permissions", "PermissionGroupId", c => c.Int());
            DropColumn("dbo.PermissionGroups", "PermissionGroupName");
            RenameColumn(table: "dbo.Permissions", name: "PermissionGroupId", newName: "PermissionGroup_PermissionGroupId");
            CreateIndex("dbo.Permissions", "PermissionGroup_PermissionGroupId");
            AddForeignKey("dbo.Permissions", "PermissionGroup_PermissionGroupId", "dbo.PermissionGroups", "PermissionGroupId");
        }
    }
}
