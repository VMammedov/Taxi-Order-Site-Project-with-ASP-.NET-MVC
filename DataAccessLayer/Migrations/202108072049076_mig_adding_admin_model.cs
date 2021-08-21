namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_admin_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewsStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "NewsStatus");
        }
    }
}
