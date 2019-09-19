using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    public class RoomFurniture
    {
        [Key]
        public int Id { set; get; }

        [Key]
        [ForeignKey("RoomId")]
        public int? RoomId { get; set; }

        [Key]
        [ForeignKey("FurnitureId")]
        public int? FurnitureId { get; set; }

        public int Count { set; get; }
    }
}
