using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.EntityModels
{
    public class AllBookingInformation
    {
        public string _FullName { set; get; }
        public int _RoomNumber { set; get; }
        public List<RoomFurniture> _FurnitureList { set; get; }
        public List<BookingTechnic> _TechnicList { set; get; }
        public DateTime _StartTime { set; get; }
        public DateTime _EndTime { set; get; }
        public int _Cost { get; set; }
    }
}
