namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_prop_to_notification_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "NotificationStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "NotificationStatus");
        }
    }
}
