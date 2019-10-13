using EntityModel.EntityModels;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reservation.ReservationInfo;

namespace Reservation
{
    public class UserManager : Manager.Manager
    {
        public void Add(UserModel model)
        {
            using (ReservContext db = new ReservContext())
            {
                var user = db.Users.Add(new User
                {
                    Name = model._FirstName,
                    LastName = model._LastName
                });
            }
        }

        public void Edit(UserModel model)
        {
            using (ReservContext db = new ReservContext())
            {
                var user_edit = db.Users.Where(i => i.Id == model._Id).FirstOrDefault();
                user_edit.Name = model._FirstName;
                user_edit.LastName = model._LastName;
                db.SaveChanges();
            }
        }

        public UserModel[] GetUsers()
        {
            using (ReservContext db = new ReservContext())
            {
                var users = (from u in db.Users
                             select new UserModel
                             {
                                 _Id = u.Id,
                                 _FirstName = u.Name,
                                 _LastName = u.LastName
                             }).ToArray();

                return users;
            }
        }

        public User Find(int id)
        {
            using (ReservContext db = new ReservContext())
            {
                User u = (User)Find(id, "Users");
                return u;
            }
        }

        public User RemoveById(int id)
        {
            User u = (User)RemoveById(id, "Users");
            return u;
        }

        public void Add(User user)
        {
            if (user.Name.Length >= 3 && user.LastName.Length >= 3)
            {
                using (ReservContext db = new ReservContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }

        public void ChangeName(string fName, string lName, int id)
        {
            if (fName.Length >= 3 && lName.Length >= 3)
            {
                using (ReservContext db = new ReservContext())
                {
                    var user = db.Users.FirstOrDefault<User>(u => u.Id == id);
                    if (user != null)
                    {
                        user.Name = fName;
                        user.LastName = lName;
                    }
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (ReservContext db = new ReservContext())
            {
                var user = db.Users.FirstOrDefault<User>(u => u.Id == id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public IQueryable GetUsersWithChar(char firstInitial)
        {
            using (ReservContext db = new ReservContext())
            {
                var user = db.Users.Where<User>
                    (u => u.Name.Contains(firstInitial));
                db.SaveChanges();
                return user;
            }

        }

        public PersonInfo[] GetUserReservations()
        {
            using (ReservContext db = new ReservContext())
            {
                var personinfo = from user in db.Users
                                 join booking in db.BookingUsers on user.Id equals booking.UserId
                                 group booking by user into gr
                                 select new PersonInfo
                                 {
                                     _Name = gr.Key.Name,
                                     _Balance = gr.Key.Balance,
                                     _ReservInfo = gr.Select(i => new ReservationInfo
                                     {
                                         _RoomId = i.Booking.RoomId,
                                         _ReservStart = i.Booking.StartTime
                                     })
                                 };


                return personinfo.ToArray<PersonInfo>();
            }
        }

        //private bool _disposed;

        //ReservContext db = new ReservContext();
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();

        //        }
        //    }
        //    _disposed = true;
        //}
    }
}
