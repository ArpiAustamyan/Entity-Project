namespace Reservation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Furniture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Furnitures", "HourlyCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Furnitures", "HourlyCost");
        }
    }
}
