namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_notification_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        NotificationTitle = c.String(maxLength: 50),
                        NotificationContent = c.String(maxLength: 300),
                        NotificationTime = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.DriverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.Notifications", "ClientID", "dbo.Clients");
            DropIndex("dbo.Notifications", new[] { "DriverID" });
            DropIndex("dbo.Notifications", new[] { "ClientID" });
            DropTable("dbo.Notifications");
        }
    }
}
