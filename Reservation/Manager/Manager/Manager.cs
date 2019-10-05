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
