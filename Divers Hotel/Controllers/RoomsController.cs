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
    public class RoomsController : Controller
    {
        private readonly IService<Room> _context;

        public RoomsController(IService<Room> context)
        {
            _context = context;
           
        }

        // GET: Rooms
        public IActionResult Index()
        {
            return View(_context.GetAll());
        }
    }
}
