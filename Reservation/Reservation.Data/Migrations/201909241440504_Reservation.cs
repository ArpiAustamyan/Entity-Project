namespace Reservation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ActualStart = c.DateTime(nullable: false),
                        ActualEnd = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Balance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingTechnics",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        FurnitureId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookingId, t.FurnitureId })
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: false)
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: false)
                .Index(t => t.BookingId)
                .Index(t => t.FurnitureId);
            
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HourlyCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingUsers",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookingId, t.UserId })
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.BookingId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RoomFurnitures",
                c => new
                    {
                        RoomId = c.Int(nullable: false),
                        FurnitureId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomId, t.FurnitureId })
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: false)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .Index(t => t.RoomId)
                .Index(t => t.FurnitureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomFurnitures", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFurnitures", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.BookingUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.BookingUsers", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.BookingTechnics", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.BookingTechnics", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomFurnitures", new[] { "FurnitureId" });
            DropIndex("dbo.RoomFurnitures", new[] { "RoomId" });
            DropIndex("dbo.BookingUsers", new[] { "UserId" });
            DropIndex("dbo.BookingUsers", new[] { "BookingId" });
            DropIndex("dbo.BookingTechnics", new[] { "FurnitureId" });
            DropIndex("dbo.BookingTechnics", new[] { "BookingId" });
            DropIndex("dbo.Rooms", new[] { "RoomId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropTable("dbo.RoomFurnitures");
            DropTable("dbo.BookingUsers");
            DropTable("dbo.Furnitures");
            DropTable("dbo.BookingTechnics");
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
        }
    }
}
