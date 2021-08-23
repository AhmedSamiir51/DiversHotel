using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divers_Hotel.Models;

namespace Divers_Hotel.Models
{
    public class HotelModel:DbContext
    {
        public HotelModel( DbContextOptions option ):base(option)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<ReservationModel> ReservationModel { get; set; }
        public virtual DbSet<MealPlan> MealPlans { get; set; }

        public virtual DbSet<MealSeason> MealSeasons { get; set; }
        public virtual DbSet<RoomSeason> RoomSeasons { get; set; }

        public virtual DbSet<PriceRoomsPerSeason> PriceRoomsPerSeason { get; set; }
        public virtual DbSet<PriceMealsPerSeason> PriceMealsPerSeasons { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<PriceMealsPerSeason>().HasKey(table => new {
                table.MealID,
                table.SeasonId
            });

            builder.Entity<PriceRoomsPerSeason>().HasKey(table => new {
                table.IdRoom,
                table.IdSeason
            });

        }

      


    }
}
