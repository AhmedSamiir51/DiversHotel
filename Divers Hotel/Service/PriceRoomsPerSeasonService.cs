using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class PriceRoomsPerSeasonService : IServicePriceRooms<PriceRoomsPerSeason>
    {

        private readonly HotelModel _db;

        public PriceRoomsPerSeasonService(HotelModel db)
        {
            _db = db;
        }

        public void Create(PriceRoomsPerSeason entity)
        {
            _db.PriceRoomsPerSeason.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int idRoom, int idSeason)
        {
            var Price = _db.PriceRoomsPerSeason.Where(e => e.IdRoom == idRoom && e.IdSeason == idSeason).FirstOrDefault();
            _db.PriceRoomsPerSeason.Remove(Price);
            _db.SaveChanges();
        }

        public void Edit(int idRoom, int idSeason, PriceRoomsPerSeason entity)
        {
            var Price = _db.PriceRoomsPerSeason.Where(e => e.IdRoom == idRoom && e.IdSeason == idSeason).FirstOrDefault();
            Price.IdSeason = entity.IdSeason;
            Price.Price = entity.Price;

            _db.SaveChanges();
        }

        public IEnumerable<PriceRoomsPerSeason> GetAll()
        {
            return _db.PriceRoomsPerSeason.ToList();
        }

        public PriceRoomsPerSeason GetById(int idRoom, int idSeason)
        {
            return _db.PriceRoomsPerSeason.Where(e => e.IdRoom == idRoom && e.IdSeason == idSeason).FirstOrDefault();
        }
    }
}
