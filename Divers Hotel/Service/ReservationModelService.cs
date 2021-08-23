using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class ReservationModelService : IReservation
    {
        private readonly HotelModel _db;

        public ReservationModelService(HotelModel db)
        {
            _db = db;
        }

        public void create(ReservationModel model)
        {
            try
            {
                _db.ReservationModel.Add(model);
                _db.SaveChanges();
            }
            catch (Exception ex )
            {

                throw;
            }
           
        }

        public int GetReservationTotal(DateTime check_in, DateTime check_out, int guests, int roomtype, int meal)
        {
            try
            {
                var MealSeason = _db.MealSeasons.Where(e => e.From <= check_in && e.To >= check_out).Select(e => e.Id).FirstOrDefault();
                var PriceMeals = _db.PriceMealsPerSeasons.Where(e => e.MealID == meal && e.SeasonId == MealSeason).Select(e => e.Price).FirstOrDefault();

                var RoomSeason = _db.RoomSeasons.Where(e => e.From <= check_in && e.To >= check_out).Select(e => e.SeasonID).FirstOrDefault();

                var price = _db.PriceRoomsPerSeason.Where(e => e.IdRoom == roomtype && e.IdSeason == RoomSeason).Select(e => e.Price).FirstOrDefault();

                var Day = check_out - check_in;
                var result = Day.Days * price + Day.Days*PriceMeals;

                var TotalPrice = result * guests;



                return TotalPrice;

            }
            catch (Exception ex )
            {

                throw;
            }
           
        }
    }
}
