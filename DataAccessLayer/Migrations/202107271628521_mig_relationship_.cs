namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_relationship_ : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.Orders", new[] { "DriverID", "ClientID" });
        }
    }
}
