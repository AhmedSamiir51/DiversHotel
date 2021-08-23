using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public class MealPlanService : IService<MealPlan>
    {
        private readonly HotelModel _db;

        public MealPlanService(HotelModel db)
        {
            _db = db;
        }
        public MealPlan Create(MealPlan entity)
        {
            _db.MealPlans.Add(entity);
            _db.SaveChanges();
            return entity;

        }

        public void Delete(int id)
        {
            var meal = _db.MealPlans.Where(e => e.MealId == id).FirstOrDefault();
            _db.MealPlans.Remove(meal);
            _db.SaveChanges();

        }

        public void Edit(int id, MealPlan entity)
        {
            var meal = _db.MealPlans.Where(e => e.MealId == id).FirstOrDefault();
            meal.Name = entity.Name;
         
            _db.SaveChanges();

        }

        public IEnumerable<MealPlan> GetAll()
        {
            return _db.MealPlans.ToList();
        }

        public MealPlan GetById(int id )
        {
            return _db.MealPlans.Where(e => e.MealId == id).FirstOrDefault();
        }

        public MealPlan Login(string User, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
