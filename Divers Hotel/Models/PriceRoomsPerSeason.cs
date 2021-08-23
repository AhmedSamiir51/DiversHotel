using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class PriceRoomsPerSeason
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Room")]
        public int IdRoom { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("RoomSeason")]
        public int IdSeason { get; set; }

        [Column(Order = 2)]
        public int Price { get; set; }
        public virtual Room Room { get; set; }
        public virtual RoomSeason RoomSeason { get; set; }
    }
}
