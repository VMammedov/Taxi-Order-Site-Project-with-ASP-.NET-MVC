namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deleting_prop_in_orders : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "NameSurName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "NameSurName", c => c.String(maxLength: 100));
        }
    }
}
