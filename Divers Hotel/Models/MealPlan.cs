using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class MealPlan
    {
        [Key]
        public int MealId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<PriceMealsPerSeason> priceMealsPerSeasons { get; set; }

    }
}
