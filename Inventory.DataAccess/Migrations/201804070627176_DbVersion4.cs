namespace Inventory.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbVersion4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NIC", c => c.String());
            AddColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "Qty", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "Discount", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "Tax", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "Qty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Items", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Items", "CategoryId");
            DropColumn("dbo.Customers", "NIC");
        }
    }
}
