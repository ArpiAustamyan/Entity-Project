using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class RoomFurnitureContext:DbContext
    {
        public RoomFurnitureContext() : base("Reservation") { }

        public DbSet<RoomFurniture> RoomFurnitures { get; set; }

    }
}
