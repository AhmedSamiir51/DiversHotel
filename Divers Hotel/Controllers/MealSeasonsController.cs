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
    public class MealSeasonsController : Controller
    {


        private readonly IService<MealSeason> _context;

        public MealSeasonsController(IService<MealSeason> context)
        {
            _context = context;

        }
        // GET: MealSeasons
        public IActionResult Index()
        {
            return View( _context.GetAll());
        }

        // GET: MealSeasons/Details/5
        public IActionResult Details(int id)
        {
            var mealSeason = _context.GetById(id);
            if (mealSeason == null)
            {
                return NotFound();
            }
            return View(mealSeason);
        }

        // GET: MealSeasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealSeasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( MealSeason mealSeason)
        {
            if (ModelState.IsValid)
            {
                _context.Create(mealSeason);
                return RedirectToAction(nameof(Index));
            }
            return View(mealSeason);
        }

        // GET: MealSeasons/Edit/5
        public IActionResult Edit(int id)
        {

            var mealSeason = _context.GetById(id);
            if (mealSeason == null)
            {
                return NotFound();
            }
            return View(mealSeason);
        }

        // POST: MealSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,From,To")] MealSeason mealSeason)
        {
            if (id != mealSeason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                    _context.Edit(id, mealSeason);
               
                return RedirectToAction(nameof(Index));
            }
            return View(mealSeason);
        }

        // GET: MealSeasons/Delete/5
        public IActionResult Delete(int id)
        {

            var mealSeason =  _context.GetById(id);
            if (mealSeason == null)
            {
                return NotFound();
            }

            return View(mealSeason);
        }

        // POST: MealSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
