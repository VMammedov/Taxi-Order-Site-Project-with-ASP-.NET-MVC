namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_admin_model_real : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(maxLength: 30),
                        AdminMail = c.String(nullable: false, maxLength: 60),
                        AdminPasswordHash = c.Binary(),
                        AdminPasswordSalt = c.Binary(),
                        AdminRole = c.String(maxLength: 1),
                        AdminStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
