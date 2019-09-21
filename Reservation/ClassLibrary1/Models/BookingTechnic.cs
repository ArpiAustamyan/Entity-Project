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
        [Key]
        public int? BookingId { get; set; }

        [Key]
        public int? FurnitureId { get; set; }

        public int Count { set; get; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [ForeignKey("FurnitureId")]
        public Furniture Furniture { get; set; }
    }
}
