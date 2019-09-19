using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class RoomContext : DbContext
    {
        public RoomContext() : base("Reservation") { }

        public DbSet<Room> Rooms { get; set; }
    }
}
