namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_number_props : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "ClientNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Orders", "Number", c => c.String(maxLength: 20));
            AlterColumn("dbo.Drivers", "DriverNumber", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "DriverNumber", c => c.String());
            AlterColumn("dbo.Orders", "Number", c => c.String());
            AlterColumn("dbo.Clients", "ClientNumber", c => c.String());
        }
    }
}
