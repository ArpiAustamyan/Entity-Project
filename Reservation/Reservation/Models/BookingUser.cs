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
        [Key]
        public int Id { set; get; }

        [Key]
        [ForeignKey("BookingId")]
        public int? BookingId { get; set; }

        [Key]
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
    }
}
