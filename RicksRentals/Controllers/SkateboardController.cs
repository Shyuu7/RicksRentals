using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RicksRentals.Data;
using RicksRentals.Models;

namespace RicksRentals.Controllers
{
    public class SkateboardController : Controller
    {
        private readonly masterContext _context;

        public SkateboardController(masterContext context)
        {
            _context = context;
        }

        // GET: Skateboard
        public async Task<IActionResult> Index()
        {
              return _context.Skateboard != null ? 
                          View(await _context.Skateboard.ToListAsync()) :
                          Problem("Entity set 'masterContext.Skateboard'  is null.");
        }

        // GET: Skateboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skateboard == null)
            {
                return NotFound();
            }

            var skateboard = await _context.Skateboard
                .FirstOrDefaultAsync(m => m.SkateId == id);
            if (skateboard == null)
            {
                return NotFound();
            }

            return View(skateboard);
        }

        // GET: Skateboard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skateboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkateId,Brand,Model,DailyRate,RentalDate")] Skateboard skateboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skateboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skateboard);
        }

        // GET: Skateboard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skateboard == null)
            {
                return NotFound();
            }

            var skateboard = await _context.Skateboard.FindAsync(id);
            if (skateboard == null)
            {
                return NotFound();
            }
            return View(skateboard);
        }

        // POST: Skateboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkateId,Brand,Model,DailyRate,RentalDate")] Skateboard skateboard)
        {
            if (id != skateboard.SkateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skateboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkateboardExists(skateboard.SkateId))
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
            return View(skateboard);
        }

        // GET: Skateboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skateboard == null)
            {
                return NotFound();
            }

            var skateboard = await _context.Skateboard
                .FirstOrDefaultAsync(m => m.SkateId == id);
            if (skateboard == null)
            {
                return NotFound();
            }

            return View(skateboard);
        }

        // POST: Skateboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skateboard == null)
            {
                return Problem("Entity set 'masterContext.Skateboard'  is null.");
            }
            var skateboard = await _context.Skateboard.FindAsync(id);
            if (skateboard != null)
            {
                _context.Skateboard.Remove(skateboard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkateboardExists(int id)
        {
          return (_context.Skateboard?.Any(e => e.SkateId == id)).GetValueOrDefault();
        }
    }
}
