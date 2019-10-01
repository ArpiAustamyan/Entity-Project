using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Manager
{
     public class FurnitureManager: Manager, IDisposable
     {
        public Furniture Find(int id)
        {
            Furniture f = (Furniture)Find( id, "Furnitures");
            return f;
        }

        public Furniture RemoveById(int id)
        {
            Furniture f = (Furniture)RemoveById(id, "Furnitures");
            return f;
        }

        private bool _disposed;

        ReservContext db = new ReservContext();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    db.Dispose();

                }
            }
            _disposed = true;
        }
    }
}
