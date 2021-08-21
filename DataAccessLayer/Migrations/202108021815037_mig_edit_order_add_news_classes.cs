namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_order_add_news_classes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsHeading = c.String(maxLength: 50),
                        NewsValue = c.String(maxLength: 1000),
                        NewsDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID);
            
            AddColumn("dbo.Orders", "NameSurName", c => c.String(maxLength: 100));
            AddColumn("dbo.Orders", "PickUpLocation", c => c.String(maxLength: 150));
            AddColumn("dbo.Orders", "DropLocation", c => c.String(maxLength: 150));
            AddColumn("dbo.Orders", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Number");
            DropColumn("dbo.Orders", "DropLocation");
            DropColumn("dbo.Orders", "PickUpLocation");
            DropColumn("dbo.Orders", "NameSurName");
            DropTable("dbo.News");
        }
    }
}
