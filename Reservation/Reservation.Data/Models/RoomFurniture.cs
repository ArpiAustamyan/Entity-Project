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
        [Key ,Column(Order = 1)]
        public int RoomId { get; set; }

        [Key, Column(Order = 2)]
        public int FurnitureId { get; set; }

        public int Count { set; get; }

        [ForeignKey("RoomId")]
        public Room Room { set; get; }

        [ForeignKey("FurnitureId")]
        public Furniture Furniture { set; get; }
    }
}
