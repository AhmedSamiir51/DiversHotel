using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class MealSeason
    {
        [Key]
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string NameSeason { get; set; }


        public List<PriceMealsPerSeason> priceMealsPerSeasons { get; set; }
    }
}
