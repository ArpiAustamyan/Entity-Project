using Reservation.EntityModels;
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

        public void Add(BookingModel model)
        {
            Booking booking = new Booking
            {
                StartTime = model._StratTime,
                EndTime = model._EndTime,
                RoomId = model._RoomNumber,
                UserId = model._UserId
            };

            var booking_user = model._Users.Select(i => new BookingUser
            {
                Booking = booking,
                UserId = i
            });

            var booking_furn = model._Technic.Select(i => new BookingTechnic
            {
                Booking = booking,
                FurnitureId = db.BookingTechnics.Where(l => l.Furniture.Name == i._Name).FirstOrDefault().FurnitureId,
                Count = i._Count
            });
            
            db.BookingUsers.AddRange(booking_user);
            db.BookingTechnics.AddRange(booking_furn);
        }

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

        public AllBookingInformation BookingInformation(int id)
        {
            var booking = from b in db.Bookings
                          join bt in db.BookingTechnics on b.Id equals bt.BookingId
                          group bt by b into gr
                          join rf in db.RoomFurnitures on gr.Key.Id equals rf.RoomId
                          join r in db.Rooms on rf.FurnitureId equals r.Id
                          group rf by new { gr, r } into gr1
                          where gr1.Key.gr.Key.Id == id
                          select new AllBookingInformation
                          {
                              _FullName = gr1.Key.gr.Key.User.Name + " /t" + gr1.Key.gr.Key.User.LastName,
                              _RoomNumber = gr1.Key.r.Id,
                              _FurnitureList=gr1.ToList(),
                              _TechnicList = gr1.Key.gr.ToList(),
                              _StartTime=gr1.Key.gr.Key.StartTime,
                              _EndTime = gr1.Key.gr.Key.EndTime,
                              _Cost = gr1.Key.r.Price +
                              gr1.Sum(i => i.Count * i.Furniture.HourlyCost) * (gr1.Key.gr.Key.EndTime.Hour - gr1.Key.gr.Key.StartTime.Hour) +
                              gr1.Key.gr.Sum(i => i.Count * i.Furniture.HourlyCost) * (gr1.Key.gr.Key.EndTime.Hour - gr1.Key.gr.Key.StartTime.Hour)
                          };
            return booking.FirstOrDefault();
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
