using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikesCRUD.Data;
using BikesCRUD.Models;

namespace BikesCRUD.Controllers
{
    public class BikesController : Controller
    {
        private readonly BikesCRUDContext _context;

        public BikesController(BikesCRUDContext context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
              return _context.Bike != null ? 
                          View(await _context.Bike.ToListAsync()) :
                          Problem("Entity set 'BikesCRUDContext.Bike'  is null.");
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .FirstOrDefaultAsync(m => m.BikeId == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BikeId,BikeName,BikeType,BikeColour,BikeDescription")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BikeId,BikeName,BikeType,BikeColour,BikeDescription")] Bike bike)
        {
            if (id != bike.BikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.BikeId))
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
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .FirstOrDefaultAsync(m => m.BikeId == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Bike == null)
            {
                return Problem("Entity set 'BikesCRUDContext.Bike'  is null.");
            }
            var bike = await _context.Bike.FindAsync(id);
            if (bike != null)
            {
                _context.Bike.Remove(bike);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(string id)
        {
          return (_context.Bike?.Any(e => e.BikeId == id)).GetValueOrDefault();
        }
    }
}
