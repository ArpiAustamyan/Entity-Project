using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class BookingManager : IDisposable
    {

        public void Find(int id)
        {
            var booking = db.Bookings.FirstOrDefault<Booking>(b => b.Id == id);
            if (booking != null)
            {
                Console.WriteLine(booking.User.Name + booking.User.LastName);
                Console.WriteLine("RoomId" + booking.RoomId);
                var roomFur = db.RoomFurnitures
                    .Where<RoomFurniture>(rf => rf.RoomId == booking.RoomId);
                foreach (RoomFurniture rf in roomFur)
                {
                    Console.WriteLine("{0}.{1} ", rf.Furniture.Name, rf.Count);
                }

                var bookFur = db.BookingTechnics
                   .Where<BookingTechnic>(bt => bt.BookingId == booking.Id);
                foreach (BookingTechnic bt in bookFur)
                {
                    Console.WriteLine("{0}.{1} ", bt.Furniture.Name, bt.Count);
                }
                Console.WriteLine(booking.ActualStart + "  " + booking.ActualEnd);
                Console.WriteLine(booking.Room.Price + booking.Room.Rooms.Price);
                var bu = db.BookingUsers
                    .Where<BookingUser>(b => b.BookingId == id)
                    .Count<BookingUser>();
                Console.WriteLine(bu);

            }
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
