using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class BookingManager : Manager.Manager, IDisposable
    {
        public Booking Find(int id)
        {
            Booking b = (Booking)Find(id, "Bookings");
            return b;
        }

        public Booking RemoveById(int id)
        {
            Booking b = (Booking)RemoveById(id, "Bookings");
            return b;
        }

        public Booking[] SearchReservations(string userNameStart)
        {
            var booking = (from b in db.Bookings
                           join u in db.Users on b.UserId equals u.Id
                           where u.Name.StartsWith(userNameStart)
                           select b)
                           .ToArray();
            return booking;
        }

        public Booking[] SearchReservations(string userNameStart, int cost)
        {
            var booking = (from b in db.Bookings
                           join u in db.Users on b.UserId equals u.Id
                           where u.Name.StartsWith(userNameStart)
                           join r in db.Rooms on b.RoomId equals r.Id
                           where r.Price == cost
                           select b)
                           .ToArray();
            return booking;
        }

        //public void Find(int id)
        //{
        //    var booking = from b in db.Bookings
        //                  where b.Id == id
        //                  join bf in db.BookingTechnics on b.Id equals bf.BookingId
        //                  group bf by b into gr
        //                  join r in db.Rooms on b.RoomId equals r.Id
        //                  join rf in db.RoomFurnitures on r.Id equals rf.RoomId
        //                  group rf by r into gr1
        //                  select new
        //                  {
        //                      //  FullName=
        //                  };
        //}

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
