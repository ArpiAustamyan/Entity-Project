using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class RoomManager
    {
        public int GetCost(int id)
        {
            using (ReservContext db = new ReservContext())
            {
                var roomFurCost = (from rf in db.RoomFurnitures
                                   join f in db.Furnitures
                                   on rf.FurnitureId equals f.Id
                                   where rf.RoomId == id
                                   select new
                                   {
                                       //Room_Price = rf.Sum(i => new
                                       //{
                                       //    oneFurPrice = i.Furniture.HourlyCost * i.Count
                                       //}
                                   }
                                  );

                return 0;
              //  return roomFurCost;
            }

        }
    }
}
