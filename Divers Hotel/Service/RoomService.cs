using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class RoomService : IService<Room>
    {
        private readonly HotelModel _db;

        public RoomService(HotelModel db)
        {
            _db = db;
        }

        public Room Create(Room entity)
        {
            _db.Rooms.Add(entity);
            _db.SaveChanges();
            return entity; 
        }

        public void Delete(int id)
        {
            var room = _db.Rooms.Where(e => e.RoomId == id).FirstOrDefault();
            _db.Rooms.Remove(room);
            _db.SaveChanges();
        }

        public void Edit(int id, Room entity)
        {
            var room = _db.Rooms.Where(e => e.RoomId == id).FirstOrDefault();
          
            room.RoomId = entity.RoomId;
            room.RoomType = entity.RoomType;
            room.Description = entity.Description;
            _db.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return _db.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _db.Rooms.Where(e => e.RoomId == id).FirstOrDefault();
        }

        public Room Login(string User, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
