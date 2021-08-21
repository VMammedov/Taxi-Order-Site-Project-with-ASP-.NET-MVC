namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_orders_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .Index(t => t.DriverID)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "ClientID", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "ClientID" });
            DropIndex("dbo.Orders", new[] { "DriverID" });
            DropTable("dbo.Orders");
        }
    }
}
