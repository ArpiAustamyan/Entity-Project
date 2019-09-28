using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reservation.ReservationInfo;

namespace Reservation
{
    public class UserManager
    {
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
    }
}
