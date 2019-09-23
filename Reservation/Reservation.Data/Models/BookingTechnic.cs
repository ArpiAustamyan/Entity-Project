using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class BookingTechnic
    {
        [Key ,Column(Order =1)]
        public int? BookingId { get; set; }

        [Key, Column(Order = 2)]
        public int? FurnitureId { get; set; }

        public int Count { set; get; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [ForeignKey("FurnitureId")]
        public Furniture Furniture { get; set; }
    }
}
