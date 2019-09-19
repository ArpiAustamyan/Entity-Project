using Reservation.Context;
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

            using (RoomContext db = new RoomContext())
            {
                Room room1 = new Room { Price = 2000 };
                Room room2 = new Room { Price = 3000 };

                db.Rooms.Add(room1);
                db.Rooms.Add(room2);
                db.SaveChanges();


                var rooms = db.Rooms;
                foreach (Room r in rooms)
                {
                    Console.WriteLine("{0}.{1} ", r.Id,r.Price);
                }

            }
            using (UserContext db = new UserContext())
            {

                User user1 = new User { FristName = "Tom", LastName = "Simson" };
                User user2 = new User { FristName = "Sam", LastName = "Henderson" };


                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();


                var users = db.Users;
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.FristName, u.LastName);
                }
            }

            Console.Read();
        }
    }
}
