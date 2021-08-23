using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class UserService : IService<User>
    {
        private readonly HotelModel _db;

        public UserService(HotelModel db)
        {
            _db = db;
        }

        public User Create(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var user = _db.Users.Where(e => e.UserId == id).FirstOrDefault();
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void Edit(int id, User entity)
        {
            var user = _db.Users.Where(e => e.UserId == id).FirstOrDefault();
            user.UserName = entity.UserName;
            user.Email = entity.Email;
            user.Country = entity.Country;
            user.Age = entity.Age;
            _db.SaveChanges();

        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.Where(e => e.UserId == id).FirstOrDefault();
        }

        public User Login(string User, string Password)
        {
           var user= _db.Users.Where(e => e.UserName == User && e.Password == Password).FirstOrDefault();
            return user;
        }
    }
}