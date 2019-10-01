namespace Reservation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reserv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Booking_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "User_Id");
            CreateIndex("dbo.Users", "Booking_Id");
            AddForeignKey("dbo.Bookings", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Booking_Id", "dbo.Bookings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Booking_Id" });
            DropIndex("dbo.Bookings", new[] { "User_Id" });
            DropColumn("dbo.Users", "Booking_Id");
            DropColumn("dbo.Bookings", "User_Id");
        }
    }
}
