using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (ReservContext db = new ReservContext())
            {
                //Room room1 = new Room { Price = 2000 };
                //Room room2 = new Room { Price = 3000 };

                //db.Rooms.Add(room1);
                //db.Rooms.Add(room2);
                //db.SaveChanges();

                //User user1 = new User { Name = "Tom", LastName = "Simson" };
                //User user2 = new User { Name = "Sam", LastName = "Henderson" };

                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.SaveChanges();
                //Booking booking1 = new Booking { StartTime=Convert.ToDateTime("2019-10-02"),
                //    EndTime = Convert.ToDateTime("2019-10-03"),
                //    ActualStart = Convert.ToDateTime("2019-10-02"),
                //    ActualEnd = Convert.ToDateTime("2019-10-03"),
                //    RoomId =1, UserId=1 };
                //db.Bookings.Add(booking1);
                //db.SaveChanges();
                var bookings = db.Bookings;
                foreach (Booking b in bookings)
                {
                    Console.WriteLine("{0}.{1}", b.Id, b.StartTime);
                }

                var rooms = db.Rooms;
                foreach (Room r in rooms)
                {
                    Console.WriteLine("{0}.{1}", r.Id, r.Price);
                }

                var users = db.Users;
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1}", u.Id, u.Name);
                }

            }

            Console.Read();

        }
    }
}
