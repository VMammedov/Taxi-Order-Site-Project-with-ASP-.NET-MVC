namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_luggagetransfer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PickUpTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "PickUpTime");
        }
    }
}
