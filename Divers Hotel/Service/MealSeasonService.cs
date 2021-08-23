using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class MealSeasonService : IService<MealSeason>
    {
        private readonly HotelModel _db;

        public MealSeasonService(HotelModel db)
        {
            _db = db;
        }

        public MealSeason Create(MealSeason entity)
        {
            _db.MealSeasons.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var season = _db.MealSeasons.Where(e => e.Id == id).FirstOrDefault();
            _db.MealSeasons.Remove(season);
            _db.SaveChanges();
        }

        public void Edit(int id, MealSeason entity)
        {
            var season = _db.MealSeasons.Where(e => e.Id == id).FirstOrDefault();
            season.From = entity.From;
            season.To = entity.To;
            season.NameSeason = entity.NameSeason;

            _db.SaveChanges();
        }

        public IEnumerable<MealSeason> GetAll()
        {
            return _db.MealSeasons.ToList();
        }

        public MealSeason GetById(int id)
        {
            return _db.MealSeasons.Where(e => e.Id == id).FirstOrDefault();
        }

        public MealSeason Login(string User, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
