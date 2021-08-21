namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deleting_orders_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Orders", new[] { "DriverID" });
            DropIndex("dbo.Orders", new[] { "ClientID" });
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateIndex("dbo.Orders", "ClientID");
            CreateIndex("dbo.Orders", "DriverID");
            AddForeignKey("dbo.Orders", "DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ClientID", "dbo.Clients", "ClientID", cascadeDelete: true);
        }
    }
}
