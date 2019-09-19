using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class BookingUserContext : DbContext
    {
        public BookingUserContext() : base("Reservation") { }

        public DbSet<BookingUser> BookingUsers { get; set; }
    }
}
