using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class BookingTechnicContext:DbContext
    {
        public BookingTechnicContext() : base("Reservation") { }

        public DbSet<BookingTechnicContext> BookingTechnics { get; set; }
    }
}
