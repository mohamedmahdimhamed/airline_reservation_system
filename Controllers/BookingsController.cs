using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirlineReservationApp.Models;

namespace AirlineReservationApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AirlineSys_DbContext _context;

        public BookingsController(AirlineSys_DbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var airlineSys_DbContext = _context.Bookings.Include(b => b.Flight).Include(b => b.User);
            return View(await airlineSys_DbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["FligthId"] = new SelectList(_context.Flights, "FlightId", "Status");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,UserId,Passport,FligthId,DepartureAirport,ArrivalAirport,DepartureDateTime,BookingDate,TicketPrice,Status")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FligthId"] = new SelectList(_context.Flights, "FlightId", "Status", booking.FligthId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId);
            return View(booking);
        }



       
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["FligthId"] = new SelectList(_context.Flights, "FlightId", "Status", booking.FligthId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,UserId,Passport,FligthId,DepartureAirport,ArrivalAirport,DepartureDateTime,BookingDate,TicketPrice,Status")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["FligthId"] = new SelectList(_context.Flights, "FlightId", "Status", booking.FligthId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }



       



        // GET: Bookings/ConsultDemand
        public async Task<IActionResult> ConsultDemand()
        {

            var airlineSys_DbContext = _context.Bookings.Include(b => b.Flight).Include(b => b.User);
            return View(await airlineSys_DbContext.ToListAsync());
        }

        public ActionResult Refuse(int id)
        {

            Booking res = _context.Bookings.FirstOrDefault(r => r.BookingId == id);
            res.Status = "refusé";
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Accepte(int id)
        {
            TempData["Message"] = "";
            //string userName = HttpContext.Session.GetString("UserName");
            //string userSurname = HttpContext.Session.GetString("UserSurname");

            //if (userName == null)
            //{
            //    return RedirectToAction("login", "Login");
            //}

            Booking res = _context.Bookings.FirstOrDefault(r => r.BookingId == id);



            

            res.Status = "accepte";
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
