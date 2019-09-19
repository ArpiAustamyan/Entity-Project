using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Context
{
    public class FurnitureContext : DbContext
    {
        public FurnitureContext() : base("Reservation") { }

        public DbSet<Furniture> Furnitures { get; set; }
    }
}
