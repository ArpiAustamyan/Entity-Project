using System;
using System.Collections.Generic;
using System.Data.Entity;
using Reservation.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Data
{
    public class ReservContext : DbContext
    {
        public ReservContext() : base("Reservation") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Furniture> Furnitures { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<BookingTechnic> BookingTechnics { get; set; }

        public DbSet<BookingUser> BookingUsers { get; set; }

        public DbSet<RoomFurniture> RoomFurnitures { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
