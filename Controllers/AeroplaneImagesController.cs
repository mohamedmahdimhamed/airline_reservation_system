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
    public class AeroplaneImagesController : Controller
    {
        private readonly AirlineSys_DbContext _context;

        public AeroplaneImagesController(AirlineSys_DbContext context)
        {
            _context = context;
        }

        // GET: AeroplaneImages
        public async Task<IActionResult> Index()
        {
            var airlineSys_DbContext = _context.AeroplaneImages.Include(a => a.Aeroplane);
            return View(await airlineSys_DbContext.ToListAsync());
        }

        // GET: AeroplaneImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplaneImage = await _context.AeroplaneImages
                .Include(a => a.Aeroplane)
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (aeroplaneImage == null)
            {
                return NotFound();
            }

            return View(aeroplaneImage);
        }

        // GET: AeroplaneImages/Create
        public IActionResult Create()
        {
            ViewData["AeroplaneId"] = new SelectList(_context.Aeroplanes, "PlaneID", "PlaneID");
            return View();
        }

        // POST: AeroplaneImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,ImageData,AeroplaneId")] AeroplaneImage aeroplaneImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroplaneImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeroplaneId"] = new SelectList(_context.Aeroplanes, "PlaneID", "PlaneID", aeroplaneImage.AeroplaneId);
            return View(aeroplaneImage);
        }

        // GET: AeroplaneImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplaneImage = await _context.AeroplaneImages.FindAsync(id);
            if (aeroplaneImage == null)
            {
                return NotFound();
            }
            ViewData["AeroplaneId"] = new SelectList(_context.Aeroplanes, "PlaneID", "PlaneID", aeroplaneImage.AeroplaneId);
            return View(aeroplaneImage);
        }

        // POST: AeroplaneImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,ImageData,AeroplaneId")] AeroplaneImage aeroplaneImage)
        {
            if (id != aeroplaneImage.ImageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroplaneImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroplaneImageExists(aeroplaneImage.ImageID))
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
            ViewData["AeroplaneId"] = new SelectList(_context.Aeroplanes, "PlaneID", "PlaneID", aeroplaneImage.AeroplaneId);
            return View(aeroplaneImage);
        }

        // GET: AeroplaneImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroplaneImage = await _context.AeroplaneImages
                .Include(a => a.Aeroplane)
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (aeroplaneImage == null)
            {
                return NotFound();
            }

            return View(aeroplaneImage);
        }

        // POST: AeroplaneImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroplaneImage = await _context.AeroplaneImages.FindAsync(id);
            if (aeroplaneImage != null)
            {
                _context.AeroplaneImages.Remove(aeroplaneImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroplaneImageExists(int id)
        {
            return _context.AeroplaneImages.Any(e => e.ImageID == id);
        }
    }
}
