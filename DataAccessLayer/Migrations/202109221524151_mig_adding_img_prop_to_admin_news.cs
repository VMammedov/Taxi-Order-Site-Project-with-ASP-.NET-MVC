namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_img_prop_to_admin_news : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminImage", c => c.String(maxLength: 300));
            AddColumn("dbo.News", "NewsImage", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "NewsImage");
            DropColumn("dbo.Admins", "AdminImage");
        }
    }
}
