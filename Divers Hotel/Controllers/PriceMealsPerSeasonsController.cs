using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Divers_Hotel.Models;
using Divers_Hotel.Service;

namespace Divers_Hotel.Controllers
{
    public class PriceMealsPerSeasonsController : Controller
    {
        private readonly IService<MealSeason> _season;
        private readonly IService<MealPlan> _meal;
        private readonly IServicePriceRooms<PriceMealsPerSeason> _context;

        public PriceMealsPerSeasonsController(IService<MealSeason> Season, IService<MealPlan> Meal, IServicePriceRooms<PriceMealsPerSeason> context)
        {
            _season = Season;
            _meal = Meal;
            _context = context;
        }

        // GET: PriceMealsPerSeasons
        public IActionResult Index()
        {

            ViewBag.Season = _season.GetAll();
            ViewBag.Meal = _meal.GetAll();

            var hotelModel = _context.GetAll();
            return View(hotelModel);
        }

        // GET: PriceMealsPerSeasons/Details/5
        public IActionResult Details(int IdMeals, int idSeason)
        {
            ViewBag.Season = _season.GetAll();
            ViewBag.Meal = _meal.GetAll();

            var room = _context.GetById(IdMeals, idSeason);

            return View(room);
        }

        // GET: PriceMealsPerSeasons/Create
        public IActionResult Create()
        {
            ViewBag.MealID = new SelectList(_meal.GetAll(), "MealId", "Name");
            ViewBag.SeasonId = new SelectList(_season.GetAll(), "Id", "NameSeason");
            return View();
        }

        // POST: PriceMealsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PriceMealsPerSeason priceMealsPerSeason)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Create(priceMealsPerSeason);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.MealID = new SelectList(_meal.GetAll(), "MealId", "Name", priceMealsPerSeason.MealID);
                ViewBag.SeasonId = new SelectList(_season.GetAll(), "Id", "NameSeason", priceMealsPerSeason.SeasonId);
                return View(priceMealsPerSeason);
            }
            catch (Exception)
            {
                ViewBag.MealID = new SelectList(_meal.GetAll(), "MealId", "Name", priceMealsPerSeason.MealID);
                ViewBag.SeasonId = new SelectList(_season.GetAll(), "Id", "NameSeason", priceMealsPerSeason.SeasonId);
                return View(priceMealsPerSeason);
            }

        }


        public IActionResult CreateMeal()
        {
            return View();
        }

        // POST: PriceMealsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMeal(MealPlan Meals)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _meal.Create(Meals);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

        }



        public IActionResult CreateSeason()
        {
            return View();
        }

        // POST: PriceMealsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSeason(MealSeason season)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _season.Create(season);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }

        }





        // GET: PriceMealsPerSeasons/Edit/5
        public IActionResult Edit(int IdMeals, int idSeason)
        {
            var priceMealsPerSeason = _context.GetById(IdMeals, idSeason);
            if (priceMealsPerSeason == null)
            {
                return NotFound();
            }

            ViewBag.MealID = new SelectList(_meal.GetAll(), "MealId", "Name", priceMealsPerSeason.MealID);
            ViewBag.SeasonId = new SelectList(_season.GetAll(), "Id", "NameSeason", priceMealsPerSeason.SeasonId);
            return View(priceMealsPerSeason);
        }

        // POST: PriceMealsPerSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int MealID, int SeasonId, PriceMealsPerSeason priceMealPerSeason)
        {
            _context.Edit(MealID, SeasonId, priceMealPerSeason);

            return RedirectToAction(nameof(Index));
        }

        // GET: PriceMealsPerSeasons/Delete/5
        public IActionResult Delete(int IdMeals, int idSeason)
        {
            var Meal = _context.GetById(IdMeals, idSeason);
            if (Meal == null)
            {
                return NotFound();
            }

            ViewBag.MealID = new SelectList(_meal.GetAll(), "MealId", "Name", Meal.MealID);
            ViewBag.SeasonId = new SelectList(_season.GetAll(), "Id", "NameSeason", Meal.SeasonId);
            return View(Meal);
        }

        // POST: PriceMealsPerSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int IdMeals, int idSeason)
        {
            _context.Delete(IdMeals, idSeason);
            return RedirectToAction(nameof(Index));
        }

    }
}
