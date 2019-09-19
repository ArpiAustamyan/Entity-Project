using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("Reservation") { }

        public DbSet<Booking> Bookings { get; set; }
    }
}
