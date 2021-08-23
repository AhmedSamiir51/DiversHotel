using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class PriceMealsPerSeason
    {
        [Key]
        [ForeignKey("MealPlan")]
        [Column(Order =0)]
        public int MealID { get; set; }
        [Key]
        [ForeignKey("MealSeason")]
        [Column(Order =1)]
        public int SeasonId { get; set; }
        [Column(Order =2)]
        public int Price { get; set; }


        public virtual MealPlan MealPlan { get; set; }
        public virtual MealSeason MealSeason { get; set; }
    }
}
