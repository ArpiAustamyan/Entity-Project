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

        public Booking[] SearchBookings(string userNameStart)
        {
            var booking = (from b in db.Bookings
                           join u in db.Users on b.UserId equals u.Id
                           where u.Name.StartsWith(userNameStart)
                           select b)
                           .ToArray();
            return booking;
        }

        public Booking[] SearchBookings(string userNameStart, int cost)
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

        public void Add(Booking model)
        {
            db.Bookings.Add(model);
            db.Users.Find(model.UserId).Balance -= model.Room.Price;

        }

        public void BookingInformation(int id)
        {
            var booking = from b in db.Bookings
                          join bt in db.BookingTechnics on b.Id equals bt.BookingId
                          group bt by b into gr
                          join rf in db.RoomFurnitures on gr.Key.Id equals rf.RoomId
                          join r in db.Rooms on rf.FurnitureId equals r.Id
                          group rf by new { gr, r } into gr1
                          where gr1.Key.gr.Key.Id == id
                          select new
                          {
                              FullName = gr1.Key.gr.Key.User.Name + " /t" + gr1.Key.gr.Key.User.LastName,
                              RoomNumber = gr1.Key.r.Id,
                              FurnitureList=gr1.ToList(),
                              TechnicList = gr1.Key.gr.ToList(),
                              Cost = gr1.Key.r.Price +
                              gr1.Sum(i => i.Count * i.Furniture.HourlyCost) * (gr1.Key.gr.Key.EndTime.Hour - gr1.Key.gr.Key.StartTime.Hour) +
                              gr1.Key.gr.Sum(i => i.Count * i.Furniture.HourlyCost) * (gr1.Key.gr.Key.EndTime.Hour - gr1.Key.gr.Key.StartTime.Hour)
                          };
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
