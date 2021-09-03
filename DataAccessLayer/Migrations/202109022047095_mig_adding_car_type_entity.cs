namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adding_car_type_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        CarTypeID = c.Int(nullable: false, identity: true),
                        carType = c.String(),
                    })
                .PrimaryKey(t => t.CarTypeID);
            
            AddColumn("dbo.Orders", "CarTypeID", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "CarTypeID");
            AddForeignKey("dbo.Orders", "CarTypeID", "dbo.CarTypes", "CarTypeID", cascadeDelete: true);
            DropColumn("dbo.Orders", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Number", c => c.String(maxLength: 20));
            DropForeignKey("dbo.Orders", "CarTypeID", "dbo.CarTypes");
            DropIndex("dbo.Orders", new[] { "CarTypeID" });
            DropColumn("dbo.Orders", "CarTypeID");
            DropTable("dbo.CarTypes");
        }
    }
}
