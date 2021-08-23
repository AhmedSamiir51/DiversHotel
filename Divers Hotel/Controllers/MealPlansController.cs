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
    public class MealPlansController : Controller
    {


        private readonly IService<MealPlan> _context;

        public MealPlansController(IService<MealPlan> context)
        {
            _context = context;

        }

        // GET: MealPlans
        public IActionResult Index()
        {
            return View( _context.GetAll());
        }

        // GET: MealPlans/Details/5
        public IActionResult Details(int id)
        {


            var mealPlan = _context.GetById(id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            return View(mealPlan);
        }

        // GET: MealPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( MealPlan mealPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Create(mealPlan);
                return RedirectToAction(nameof(Index));
            }
            return View(mealPlan);
        }

        // GET: MealPlans/Edit/5
        public IActionResult Edit(int id)
        {
            var mealPlan =  _context.GetById(id);
            if (mealPlan == null)
            {
                return NotFound();
            }
            return View(mealPlan);
        }

        // POST: MealPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MealId,Name")] MealPlan mealPlan)
        {
            if (id != mealPlan.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Create(mealPlan);
                return RedirectToAction(nameof(Index));
            }
            return View(mealPlan);
        }

        // GET: MealPlans/Delete/5
        public IActionResult Delete(int id)
        {


            var mealPlan =  _context.GetById(id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            return View(mealPlan);
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
