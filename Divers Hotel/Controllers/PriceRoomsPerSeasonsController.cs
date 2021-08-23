using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Divers_Hotel.Models;
using Divers_Hotel.Service;
using Microsoft.AspNetCore.Authorization;

namespace Divers_Hotel.Controllers
{
    public class PriceRoomsPerSeasonsController : Controller
    {
        private readonly IService<Room> _room;
        private readonly IService<RoomSeason> _season;
        private readonly IServicePriceRooms<PriceRoomsPerSeason> _context;

        public PriceRoomsPerSeasonsController(IService<Room> Room, IService<RoomSeason> Season, IServicePriceRooms<PriceRoomsPerSeason> context)
        {
             _room = Room;
            _season = Season;
            _context = context;
        }

        [Authorize]
        // GET: PriceRoomsPerSeasons
        public IActionResult Index()
        {

            ViewBag.Season = _season.GetAll();
            ViewBag.Room = _room.GetAll();

            var hotelModel = _context.GetAll();
            return View( hotelModel );
        }

        // GET: PriceRoomsPerSeasons/Details/5
        public IActionResult Details(int idRoom, int idSeason)
        {
            ViewBag.Season = _season.GetAll();
            ViewBag.Room = _room.GetAll();

            var room = _context.GetById(idRoom, idSeason);

            return View(room);
        }

        // GET: PriceRoomsPerSeasons/Create
        public IActionResult Create()
        {
            ViewData["IdRoom"] = new SelectList(_room.GetAll(), "RoomId", "RoomType");
            ViewData["IdSeason"] = new SelectList(_season.GetAll(), "SeasonID", "NameSeason");
            return View();
        }

        // POST: PriceRoomsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( PriceRoomsPerSeason priceRoomsPerSeason)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Create(priceRoomsPerSeason);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdRoom"] = new SelectList(_room.GetAll(), "RoomId", "RoomType", priceRoomsPerSeason.IdRoom);
                ViewData["IdSeason"] = new SelectList(_season.GetAll(), "SeasonID", "NameSeason", priceRoomsPerSeason.IdSeason);
                return View(priceRoomsPerSeason);
            }
            catch (Exception)
            {
                ViewData["IdRoom"] = new SelectList(_room.GetAll(), "RoomId", "RoomType", priceRoomsPerSeason.IdRoom);
                ViewData["IdSeason"] = new SelectList(_season.GetAll(), "SeasonID", "NameSeason", priceRoomsPerSeason.IdSeason);
                return View(priceRoomsPerSeason);
            }

        }


        public IActionResult CreateRoom()
        {
            return View();
        }

        // POST: PriceRoomsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _room.Create(room);
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

        // POST: PriceRoomsPerSeasons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSeason(RoomSeason season)
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





        // GET: PriceRoomsPerSeasons/Edit/5
        public IActionResult Edit(int idRoom, int idSeason)
        {
            var room = _context.GetById(idRoom, idSeason);
            if (room == null)
            {
                return NotFound();
            }
           
            ViewData["IdRoom"] = new SelectList(_room.GetAll(), "RoomId", "Description", room.IdRoom);
            ViewData["IdSeason"] = new SelectList(_season.GetAll(), "SeasonID", "NameSeason", room.IdSeason);
            return View(room);
        }

        // POST: PriceRoomsPerSeasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idRoom, int idSeason,  PriceRoomsPerSeason priceRoomsPerSeason)
        {
            _context.Edit(idRoom, idSeason, priceRoomsPerSeason);

            return RedirectToAction(nameof(Index));
        }

        // GET: PriceRoomsPerSeasons/Delete/5
        public IActionResult Delete(int idRoom, int idSeason)
        {
            var room = _context.GetById(idRoom, idSeason);
            if (room == null)
            {
                return NotFound();
            }

            ViewData["IdRoom"] = new SelectList(_room.GetAll(), "RoomId", "Description", room.IdRoom);
            ViewData["IdSeason"] = new SelectList(_season.GetAll(), "SeasonID", "NameSeason", room.IdSeason);
            return View(room);
        }

        // POST: PriceRoomsPerSeasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idRoom, int idSeason)
        {
            _context.Delete(idRoom, idSeason);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
