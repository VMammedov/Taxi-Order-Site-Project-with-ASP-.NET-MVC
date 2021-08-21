namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updating_client_driver_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Sex", c => c.String(maxLength: 8));
            AddColumn("dbo.Clients", "ClientProfession", c => c.String(maxLength: 80));
            AddColumn("dbo.Drivers", "DriverProfession", c => c.String(maxLength: 80));
            AddColumn("dbo.Drivers", "Sex", c => c.String(maxLength: 8));
            AlterColumn("dbo.Clients", "ClientAbout", c => c.String(maxLength: 350));
            AlterColumn("dbo.Drivers", "DriverAbout", c => c.String(maxLength: 350));
            DropColumn("dbo.Clients", "ClientTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ClientTitle", c => c.String(maxLength: 80));
            AlterColumn("dbo.Drivers", "DriverAbout", c => c.String(maxLength: 250));
            AlterColumn("dbo.Clients", "ClientAbout", c => c.String(maxLength: 250));
            DropColumn("dbo.Drivers", "Sex");
            DropColumn("dbo.Drivers", "DriverProfession");
            DropColumn("dbo.Clients", "ClientProfession");
            DropColumn("dbo.Clients", "Sex");
        }
    }
}
