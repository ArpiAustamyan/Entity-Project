using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public DateTime ActualStart { set; get; }
        public DateTime ActualEnd { set; get; }
        public int? RoomId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { set; get; }
        [ForeignKey("UserId")]
        public User User { set; get; }
    }
}
