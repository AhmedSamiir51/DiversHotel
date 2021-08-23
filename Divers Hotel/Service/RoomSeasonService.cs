using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class RoomSeasonService : IService<RoomSeason>
    {
        private readonly HotelModel _db;

        public RoomSeasonService(HotelModel db)
        {
            _db = db;
        }

        public RoomSeason Create(RoomSeason entitys)
        {
            _db.RoomSeasons.Add(entitys);
            _db.SaveChanges();
            return entitys;

        }

        public void Delete(int id)
        {
            var season = _db.RoomSeasons.Where(e => e.SeasonID == id).FirstOrDefault();
            _db.RoomSeasons.Remove(season);
            _db.SaveChanges();
        }

        public void Edit(int id, RoomSeason entity)
        {
            var season = _db.RoomSeasons.Where(e => e.SeasonID == id).FirstOrDefault();
            season.From = entity.From;
            season.To = entity.To;

            _db.SaveChanges();
        }

        public IEnumerable<RoomSeason> GetAll()
        {
            return _db.RoomSeasons.ToList();
        }

        public RoomSeason GetById(int id)
        {
            return _db.RoomSeasons.Where(e => e.SeasonID == id).FirstOrDefault();
        }

        public RoomSeason Login(string User, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
