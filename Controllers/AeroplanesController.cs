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
    public class AeroplanesController : Controller
    {
        private readonly AirlineSys_DbContext _context;

        public AeroplanesController(AirlineSys_DbContext context)
        {
            _context = context;
        }

        // GET: Aeroplanes
        public IActionResult Index()
        {
            return View();
        }



        public JsonResult GetAeroplanes()
        {
            var aeroplanes = _context.Aeroplanes.ToList();
            return Json(aeroplanes);
        }



        [HttpPost]
        public JsonResult Inert(Aeroplane model)
        {
            if (ModelState.IsValid)
            {
                _context.Aeroplanes.Add(model);
                _context.SaveChanges();
                return Json("Aeroplane details saved !");
            }
            return Json("Model validation failed");
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var aeroplane = _context.Aeroplanes.Find(id);
            return Json(aeroplane);
        } 
        
        [HttpPost]
        public JsonResult Update(Aeroplane model)
        {
            if (ModelState.IsValid)
            {
                _context.Aeroplanes.Update(model);
                _context.SaveChanges();
                return Json("Aeroplane details updated .");
            }
            return Json("Model validation failed .");
        }


        [HttpPost]
public JsonResult Delete (int id)
        {
            var aeroplane = _context.Aeroplanes.Find(id);

            if (aeroplane != null)
            {
                _context.Aeroplanes.Remove(aeroplane);
                _context.SaveChanges();
                return Json("Aeroplane details deleted");
            }
            return Json($"Aeroplane details not found with id {id}");
        }



        // GET: Aeroplanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplane = await _context.Aeroplanes
                .Include(a => a.AirlineCompanyNavigationKey)
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (aeroplane == null)
            {
                return NotFound();
            }

            return View(aeroplane);
        }

        // GET: Aeroplanes/Create
        public IActionResult Create()
        {
            ViewData["AirlineCompany"] = new SelectList(_context.AirlineCompanies, "AirlineCompany", "AirlineCompany");
            ViewData["Image"] = new SelectList(_context.AeroplaneImages, "Image", "ImageData");
            return View();
        }

        // POST: Aeroplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneID,AeroplaneName,SeatingCapacity,AirlineCompany,PurchaseDate,Price,Image")] Aeroplane aeroplane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroplane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineCompany"] = new SelectList(_context.AirlineCompanies, "AirlineCompany", "AirlineCompany", aeroplane.AirlineCompanyId);
            return View(aeroplane);
        }

        // GET: Aeroplanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplane = await _context.Aeroplanes.FindAsync(id);
            if (aeroplane == null)
            {
                return NotFound();
            }
            //ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompanies, "AirlineCompanyId", "AirlineCompanyId", aeroplane.AirlineCompanyId);
            ViewData["AirlineCompanyId"] = new SelectList(_context.AirlineCompanies, "AirlineCompany", "AirlineCompanyName");
            ViewData["Image"] = new SelectList(_context.AeroplaneImages, "Image", "ImageData");
            return View(aeroplane);
        }

        // POST: Aeroplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneID,AeroplaneName,SeatingCapacity,AirlineCompany,PurchaseDate,Price,Image")] Aeroplane aeroplane)
        {
            if (id != aeroplane.PlaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroplane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroplaneExists(aeroplane.PlaneID))
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
            ViewData["AirlineCompany"] = new SelectList(_context.AirlineCompanies, "AirlineCompany", "AirlineCompany", aeroplane.AirlineCompanyId);
            return View(aeroplane);
        }

        // GET: Aeroplanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplane = await _context.Aeroplanes
                .Include(a => a.AirlineCompanyNavigationKey)
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (aeroplane == null)
            {
                return NotFound();
            }

            return View(aeroplane);
        }

        // POST: Aeroplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroplane = await _context.Aeroplanes.FindAsync(id);
            if (aeroplane != null)
            {
                _context.Aeroplanes.Remove(aeroplane);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroplaneExists(int id)
        {
            return _context.Aeroplanes.Any(e => e.PlaneID == id);
        }
    }


}
