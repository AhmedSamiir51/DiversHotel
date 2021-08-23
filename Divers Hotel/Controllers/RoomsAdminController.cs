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
    public class RoomsAdminController : Controller
    {
        private readonly IService<Room> _context;

        public RoomsAdminController(IService<Room> context)
        {
            _context = context;

        }

        // GET: RoomsAdmin
        public  IActionResult Index()
        {
            return View( _context.GetAll());
        }

        // GET: RoomsAdmin/Details/5
        public  IActionResult Details(int id)
        {
            var room =  _context.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // GET: RoomsAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Create(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: RoomsAdmin/Edit/5
        public IActionResult Edit(int id)
        {
            var room =  _context.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: RoomsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Edit(id, room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: RoomsAdmin/Delete/5
        public IActionResult Delete(int id)
        {


            var room = _context.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: RoomsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
