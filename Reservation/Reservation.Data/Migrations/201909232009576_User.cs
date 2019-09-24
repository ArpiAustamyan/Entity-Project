namespace Reservation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Balance", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "FristName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FristName", c => c.String());
            DropColumn("dbo.Users", "Balance");
            DropColumn("dbo.Users", "Name");
        }
    }
}
