using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class Booking
    {
        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public DateTime ActualStart { set; get; }
        public DateTime ActualEnd { set; get; }

        [ForeignKey("RoomId")]
        public int? RoomId { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
    }
}
