namespace Inventory.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbVersion5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Permissions", "PermissionGroupId", "dbo.PermissionGroups");
            DropIndex("dbo.Permissions", new[] { "PermissionGroupId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Permissions", "PermissionGroupId");
            AddForeignKey("dbo.Permissions", "PermissionGroupId", "dbo.PermissionGroups", "PermissionGroupId", cascadeDelete: true);
        }
    }
}
