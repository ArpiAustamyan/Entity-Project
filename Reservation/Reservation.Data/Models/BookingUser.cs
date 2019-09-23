using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class BookingUser
    {
        [Key,Column(Order = 1)]
        public int? BookingId { get; set; }

        [Key ,Column(Order = 2)]
        public int? UserId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { set; get; }

        [ForeignKey("UserId")]
        public User User { set; get; }
    }
}
