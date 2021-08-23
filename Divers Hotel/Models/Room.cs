using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual List< PriceRoomsPerSeason > priceRoomsPerSeason { get; set; }

    }
}
