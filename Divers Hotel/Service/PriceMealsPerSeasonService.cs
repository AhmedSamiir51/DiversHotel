using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class PriceMealsPerSeasonService : IServicePriceRooms<PriceMealsPerSeason>
    {

        private readonly HotelModel _db;

        public PriceMealsPerSeasonService(HotelModel db)
        {
            _db = db;
        }

        public void Create(PriceMealsPerSeason entity)
        {
            try
            {
                _db.PriceMealsPerSeasons.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(int MealIDs, int idSeason)
        {
            var Price = _db.PriceMealsPerSeasons.Where(e => e.MealID == MealIDs && e.SeasonId == idSeason).FirstOrDefault();
            _db.PriceMealsPerSeasons.Remove(Price);
            _db.SaveChanges();
        }

        public void Edit(int MealIDs, int idSeason, PriceMealsPerSeason entity)
        {
            var Price = _db.PriceMealsPerSeasons.Where(e => e.MealID == MealIDs && e.SeasonId == idSeason).FirstOrDefault();
            Price.Price = entity.Price;

            _db.SaveChanges();
        }

        public IEnumerable<PriceMealsPerSeason> GetAll()
        {
            return _db.PriceMealsPerSeasons.ToList();
        }

        public PriceMealsPerSeason GetById(int MealIDs, int idSeason)
        {
            return _db.PriceMealsPerSeasons.Where(e => e.MealID == MealIDs && e.SeasonId == idSeason).FirstOrDefault();
        }
    }
}
