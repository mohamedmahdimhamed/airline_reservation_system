using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirlineReservationApp.Models;
namespace AirlineReservationApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AirlineSys_DbContext _context;

        public LoginController(AirlineSys_DbContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            CheckSession();
            return View();
        }



        [HttpPost]
        public ActionResult Login(User A)
        {
            var x = _context.Users.Where(u => u.Email.Equals(A.Email) && u.Password.Equals(A.Password)).FirstOrDefault();
            if (x != null)
            {
                HttpContext.Session.SetString("u", A.Email);
                return RedirectToAction("Dashboard");
                TempData["Message"] = "Logging successfully!";
            }
            else
            {
                ViewBag.m = "Wrong Identifier or Password";
                TempData["Message"] = "Logging successfully!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("u");
            return RedirectToAction("Login");
        }


        public ActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("u") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        protected void CheckSession()
        {
            if (HttpContext.Session.GetString("u") == null)
            {
                RedirectToAction("Login");
            }
        }





    }
}
