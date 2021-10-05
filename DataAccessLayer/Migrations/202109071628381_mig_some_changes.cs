namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_some_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Notifications", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Notifications", new[] { "ClientID" });
            DropIndex("dbo.Notifications", new[] { "DriverID" });
            AddColumn("dbo.Notifications", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notifications", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "OrderID");
            AddForeignKey("dbo.Notifications", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            DropColumn("dbo.Notifications", "ClientID");
            DropColumn("dbo.Notifications", "DriverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "DriverID", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "ClientID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notifications", "OrderID", "dbo.Orders");
            DropIndex("dbo.Notifications", new[] { "OrderID" });
            DropColumn("dbo.Notifications", "OrderID");
            DropColumn("dbo.Notifications", "IsRead");
            CreateIndex("dbo.Notifications", "DriverID");
            CreateIndex("dbo.Notifications", "ClientID");
            AddForeignKey("dbo.Notifications", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
            AddForeignKey("dbo.Notifications", "ClientID", "dbo.Clients", "ClientID", cascadeDelete: true);
        }
    }
}
