using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Manager
{
    public class Manager
    {
        public int[] GetLengthsOf(string[] words)
        {
            return words.Select(i => i.Length).ToArray();   
        }

        public Object Find(int id, string table)
        {
            using (ReservContext db = new ReservContext())
            {
                var t = db.Set(System.Type.GetType(table)).Find(id);
                return t;          
             }
        }

        public Object RemoveById(int id, string table)
        {
            using (ReservContext db = new ReservContext())
            {
                var t = db.Set(System.Type.GetType(table)).Remove(id);
                return t;
            }
        }
    }
}

//context.Products.Add(new Product { Name = "Gini", Price = 5000 });
//context.Products.Add(new Product { Name = "Konyak", Price = 15000 });
//context.Products.Add(new Product { Name = "Shampayn", Price = 4000 });
//context.Products.Add(new Product { Name = "Tecilla", Price = 4000 });
//context.Products.Add(new Product { Name = "Hyut", Price = 2000 });
//context.Products.Add(new Product { Name = "Fresh", Price = 4000 });

//context.Branchs.Add(new Branch { Name = "Komitas" });
//context.Branchs.Add(new Branch { Name = "Zeytun" });
//context.Branchs.Add(new Branch { Name = "Masiv" });
//context.Branchs.Add(new Branch { Name = "Arabkir" });

//context.Orders.Add(new Order { Id = 1, BranchId = 1 });
//context.Orders.Add(new Order { Id = 2, BranchId = 1 });

//context.OrderProducts.Add(new OrderProduct { OrderId = 1, BranchId = 1, Count = 2,ProductId=2 });
//context.OrderProducts.Add(new OrderProduct { OrderId = 1, BranchId = 1, Count = 5, ProductId = 6 });