namespace Reservation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Rooms", "RoomId");
            AddForeignKey("dbo.Rooms", "RoomId", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Rooms", new[] { "RoomId" });
        }
    }
}
