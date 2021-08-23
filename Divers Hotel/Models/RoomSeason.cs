using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class RoomSeason
    {
        [Key]
        [Column(Order = 0)]

        public int SeasonID { get; set; }
        [Column(Order = 1)]
        public string NameSeason { get; set; }
        [Column(Order = 2)]
        public DateTime From { get; set; }

        [Column(Order = 3)]
        public DateTime To { get; set; }

        public virtual List<PriceRoomsPerSeason> priceRoomsPerSeason { get; set; }
    }
}
