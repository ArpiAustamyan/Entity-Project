using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Context : DbContext
    {
        public Context() : base("Reservation") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Furniture> Furnitures { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<BookingTechnic> BookingTechnics { get; set; }

        public DbSet<BookingUser> BookingUsers { get; set; }

        public DbSet<RoomFurniture> RoomFurnitures { get; set; }

    }
}
