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
    public class AirlineCompaniesController : Controller
    {
        private readonly AirlineSys_DbContext _context;

        public AirlineCompaniesController(AirlineSys_DbContext context)
        {
            _context = context;
        }

        // GET: AirlineCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.AirlineCompanies.ToListAsync());
        }

        // GET: AirlineCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlineCompany = await _context.AirlineCompanies
                .FirstOrDefaultAsync(m => m.AirlineCompanyId == id);
            if (airlineCompany == null)
            {
                return NotFound();
            }

            return View(airlineCompany);
        }

        // GET: AirlineCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirlineCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineCompanyId,AirlineCompanyName")] AirlineCompany airlineCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airlineCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airlineCompany);
        }

        // GET: AirlineCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlineCompany = await _context.AirlineCompanies.FindAsync(id);
            if (airlineCompany == null)
            {
                return NotFound();
            }
            return View(airlineCompany);
        }

        // POST: AirlineCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirlineCompanyId,AirlineCompanyName")] AirlineCompany airlineCompany)
        {
            if (id != airlineCompany.AirlineCompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airlineCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineCompanyExists(airlineCompany.AirlineCompanyId))
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
            return View(airlineCompany);
        }

        // GET: AirlineCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airlineCompany = await _context.AirlineCompanies
                .FirstOrDefaultAsync(m => m.AirlineCompanyId == id);
            if (airlineCompany == null)
            {
                return NotFound();
            }

            return View(airlineCompany);
        }

        // POST: AirlineCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airlineCompany = await _context.AirlineCompanies.FindAsync(id);
            if (airlineCompany != null)
            {
                _context.AirlineCompanies.Remove(airlineCompany);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineCompanyExists(int id)
        {
            return _context.AirlineCompanies.Any(e => e.AirlineCompanyId == id);
        }
    }
}
