namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_editing_models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CarType", c => c.String(maxLength: 25));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Drivers", "CarType", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "CarType");
            DropColumn("dbo.Orders", "OrderTime");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "CarType");
        }
    }
}
