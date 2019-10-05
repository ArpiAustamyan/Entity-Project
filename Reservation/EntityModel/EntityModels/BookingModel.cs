using EntityModel.EntityModels;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.EntityModels
{
    public class BookingModel
    {
        public int _RoomNumber { set; get; }
        public int _UserId { set; get; }
        public List<int> _Users { set; get; }
        public List<Technic> _Technic { set; get; }
        public DateTime _StratTime { set; get; }
        public DateTime _EndTime { set; get; }
    }
}
