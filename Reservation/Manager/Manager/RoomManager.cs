using EntityModel.EntityModels;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Room r = (Room)Find(id, "Rooms");
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

        public void Add(RoomModel model)
        {
            using (ReservContext db = new ReservContext())
            {
                Room room = new Room
                {
                    Price = model._Price,
                    RoomId = model._InnerId
                };

                var room_furn = model._FurList.Select(i => new RoomFurniture
                {
                    Room = room,
                    FurnitureId = i._Id,
                    Count = i._Count
                });

                db.RoomFurnitures.AddRange(room_furn);
                db.Rooms.Add(room);
            }
        }

        public void Edit(RoomModel model)
        {
            using (ReservContext db = new ReservContext())
            {
                var room_edit = db.Rooms.Where(i => i.Id == model._Id).FirstOrDefault();
                room_edit.Price = model._Price;
                room_edit.RoomId = model._InnerId;
                db.SaveChanges();
                //db.Entry(room_edit).State = EntityState.Modified;
            }
        }

        public RoomModel[] GetRooms()
        {
            using (ReservContext db = new ReservContext())
            {
                var rm = (from r in db.Rooms
                          join rf in db.RoomFurnitures
                          on r.Id equals rf.FurnitureId
                          group rf by r into gr
                          select new RoomModel
                          {
                              _Id = gr.Key.Id,
                              _Price = gr.Key.Price,
                              _FurList = gr.Select(i => new FurnitureModel
                              {
                                  _Id = i.FurnitureId,
                                  _Count = i.Count
                              })
                          }).ToArray();

                return rm;
            }
        }

    }
}
