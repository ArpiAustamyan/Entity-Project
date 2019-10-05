using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class RoomManager : Manager.Manager
    {
        public Room Find(int id)
        {
            using (ReservContext db = new ReservContext())
            {
                Room r =(Room)Find( id,"Rooms");
                return r;
            }
        }

        public Room RemoveById(int id)
        {
            Room r = (Room)RemoveById(id, "Rooms");
            return r;
        }

        public int GetCost(int id)
        {
            using (ReservContext db = new ReservContext())
            {
                var roomFurCost = (from rf in db.RoomFurnitures
                                   join f in db.Rooms
                                   on rf.FurnitureId equals f.Id
                                   where f.RoomId == id
                                   group rf by f into gr
                                   select gr.Key.Price + gr.Sum(i => i.Count * i.Furniture.HourlyCost)
                                  ).FirstOrDefault();

                return roomFurCost;
            }

        }
    }
}
