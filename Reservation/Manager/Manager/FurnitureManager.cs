using EntityModel.EntityModels;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Manager
{
    public class FurnitureManager : Manager, IDisposable
    {
        public void Add(FurnitureModel model)
        {
            Furniture furn = new Furniture
            {
                HourlyCost = model._Price,
                Name = model._Name
            };
            db.Furnitures.Add(furn);
        }

        public void Edit(FurnitureModel model)
        {
            var furn_edit = db.Furnitures.Where(i => i.Id == model._Id).FirstOrDefault();
            furn_edit.HourlyCost = model._Price;
            db.SaveChanges();
        }

        public FurnitureModel[] GetFurnitures()
        {
            var rm = (from f in db.Furnitures
                      select new FurnitureModel
                      {
                          _Id = f.Id,
                          _Name = f.Name,
                          _Price = f.HourlyCost
                      }).ToArray();

            return rm;
        }

        public Furniture Find(int id)
        {
            Furniture f = (Furniture)Find(id, "Furnitures");
            return f;
        }

        public Furniture RemoveById(int id)
        {
            Furniture f = (Furniture)RemoveById(id, "Furnitures");
            return f;
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
