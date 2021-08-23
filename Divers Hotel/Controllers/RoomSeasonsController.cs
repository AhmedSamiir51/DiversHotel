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
    public class RoomSeasonsController : Controller
    {
        private readonly IService<RoomSeason> _context;

        public RoomSeasonsController(IService<RoomSeason> context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int id)
        {
            var season = _context.GetById(id);
            return View(season);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomSeason season)
        {
            if (ModelState.IsValid)
            {
                _context.Create(season);
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int id)
        {

            var season = _context.GetById(id);
            if (season == null)
            {
                return NotFound();
            }
            return View(season);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RoomSeason season)
        {
            if (id != season.SeasonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Edit(id, season);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(season.SeasonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int id)
        {
            var season = _context.GetById(id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            var any = _context.GetById(id);
            if (any == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
