namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_order1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Orders", new[] { "DriverID" });
            AddColumn("dbo.Orders", "OrderStatus", c => c.String(maxLength: 1));
            AlterColumn("dbo.Orders", "DriverID", c => c.Int());
            CreateIndex("dbo.Orders", "DriverID");
            AddForeignKey("dbo.Orders", "DriverID", "dbo.Drivers", "DriverID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Orders", new[] { "DriverID" });
            AlterColumn("dbo.Orders", "DriverID", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "OrderStatus");
            CreateIndex("dbo.Orders", "DriverID");
            AddForeignKey("dbo.Orders", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
        }
    }
}
