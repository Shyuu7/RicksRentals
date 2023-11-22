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
    public class RollerbladesController : Controller
    {
        private readonly masterContext _context;

        public RollerbladesController(masterContext context)
        {
            _context = context;
        }

        // GET: Rollerblades
        public async Task<IActionResult> Index()
        {
              return _context.Rollerblades != null ? 
                          View(await _context.Rollerblades.ToListAsync()) :
                          Problem("Entity set 'masterContext.Rollerblades'  is null.");
        }

        // GET: Rollerblades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rollerblades == null)
            {
                return NotFound();
            }

            var rollerblades = await _context.Rollerblades
                .FirstOrDefaultAsync(m => m.BladesId == id);
            if (rollerblades == null)
            {
                return NotFound();
            }

            return View(rollerblades);
        }

        // GET: Rollerblades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rollerblades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BladesId,Brand,Model,DailyRate,RentalDate")] Rollerblades rollerblades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rollerblades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rollerblades);
        }

        // GET: Rollerblades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rollerblades == null)
            {
                return NotFound();
            }

            var rollerblades = await _context.Rollerblades.FindAsync(id);
            if (rollerblades == null)
            {
                return NotFound();
            }
            return View(rollerblades);
        }

        // POST: Rollerblades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BladesId,Brand,Model,DailyRate,RentalDate")] Rollerblades rollerblades)
        {
            if (id != rollerblades.BladesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rollerblades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollerbladesExists(rollerblades.BladesId))
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
            return View(rollerblades);
        }

        // GET: Rollerblades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rollerblades == null)
            {
                return NotFound();
            }

            var rollerblades = await _context.Rollerblades
                .FirstOrDefaultAsync(m => m.BladesId == id);
            if (rollerblades == null)
            {
                return NotFound();
            }

            return View(rollerblades);
        }

        // POST: Rollerblades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rollerblades == null)
            {
                return Problem("Entity set 'masterContext.Rollerblades'  is null.");
            }
            var rollerblades = await _context.Rollerblades.FindAsync(id);
            if (rollerblades != null)
            {
                _context.Rollerblades.Remove(rollerblades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollerbladesExists(int id)
        {
          return (_context.Rollerblades?.Any(e => e.BladesId == id)).GetValueOrDefault();
        }
    }
}
