using Divers_Hotel.Models;
using Divers_Hotel.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Divers_Hotel.Controllers
{
    public class UserController : Controller
    {
        private readonly IService<Room> _db;

        public IService<MealPlan> _Meal;
        private readonly IReservation _reservation;
        private readonly IService<User> _user;

        public UserController( IService<Room> db , IService<MealPlan> Meal , IReservation reservation ,IService<User> user)
        {
            _db = db;
           _Meal = Meal;
            _reservation = reservation;
           _user = user;
        }
        // GET: UserController
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (returnUrl !=null)
            {
                ViewData["ReturnUrl"] = returnUrl;
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string UserName, string Password , string returnUrl)
        {

            var user = _user.Login(UserName, Password);

            if (user!=null)
            {
                if (returnUrl ==null)
                {
                    var clamiss = new List<Claim>();
                    clamiss.Add(new Claim("username", UserName));
                    clamiss.Add(new Claim(ClaimTypes.NameIdentifier, UserName));
                    clamiss.Add(new Claim(ClaimTypes.Name, UserName));
                    clamiss.Add(new Claim(ClaimTypes.Email, "admin"));
                    var claimsIdentityw = new ClaimsIdentity(clamiss, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipadl = new ClaimsPrincipal(claimsIdentityw);

                    await HttpContext.SignInAsync(claimsPrincipadl);
                    if (user.UserName == "Ahmed")
                    {

                        return RedirectToAction("create");

                    }

                    return RedirectToAction("create");

                }
                else
                {
                    var clamis = new List<Claim>();
                    clamis.Add(new Claim("username", UserName));
                    clamis.Add(new Claim(ClaimTypes.NameIdentifier, UserName));
                    clamis.Add(new Claim(ClaimTypes.Name, UserName));
                    var claimsIdentity = new ClaimsIdentity(clamis, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect(returnUrl);
                }
               

            }
            else
            {
                ViewBag.massage = "User Name Or Password wrong";
                return View();
            }
            
            
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(User model)
        {

            var user = _user.Create(model);

            if (user != null)
            {
                var clamis = new List<Claim>();
                clamis.Add(new Claim("username", user.UserName));
                clamis.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                clamis.Add(new Claim(ClaimTypes.Name, user.UserName));
                var claimsIdentity = new ClaimsIdentity(clamis, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("create");
            }
            else
            {
                ViewBag.massage = "User Name Or Password wrong";
                return View();
            }


        }




        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Create");
        }




        // GET: UserController/Create
        public ActionResult Create()
        {
            ViewBag.Room = new SelectList(_db.GetAll(), "RoomId", "RoomType");
            ViewBag.Meal = new SelectList(_Meal.GetAll(), "MealId", "Name");

            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationModel create)
        {
            try
            {
                _reservation.create(create);

                int calc = (int)(create.Adult + create.Children);
                ViewData["Total"] = "The Total Price Is : "+ _reservation.GetReservationTotal(create.Check_In, create.Check_Out, calc , create.RoomType, create.NameMale)+ "$";
                ViewBag.Room = new SelectList(_db.GetAll(), "RoomId", "RoomType");
                ViewBag.Meal = new SelectList(_Meal.GetAll(), "MealId", "Name");

                return View("MassageCreate");
            }
            catch
            {
                ViewBag.Room = new SelectList(_db.GetAll(), "RoomId", "RoomType");
                ViewBag.Meal = new SelectList(_Meal.GetAll(), "MealId", "Name");
                return View("create");
            }
        }


    }
}
