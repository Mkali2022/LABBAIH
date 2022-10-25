using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labbeh.Data;
using Labbeh.Models;

namespace Labbeh.Controllers
{
    public class DriversCompaniesCatsssController : Controller
    {
        private readonly DBContext _context;

        public DriversCompaniesCatsssController(DBContext context)
        {
            _context = context;
        }

        // GET: DriversCompaniesCatsss
        public async Task<IActionResult> Index()
        {
              return View(await _context.DriversCompaniesCats.ToListAsync());
        }

        // GET: DriversCompaniesCatsss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriversCompaniesCats == null)
            {
                return NotFound();
            }

            var driversCompaniesCat = await _context.DriversCompaniesCats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driversCompaniesCat == null)
            {
                return NotFound();
            }

            return View(driversCompaniesCat);
        }

        // GET: DriversCompaniesCatsss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriversCompaniesCatsss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,CompaniesType")] DriversCompaniesCat driversCompaniesCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driversCompaniesCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driversCompaniesCat);
        }

        // GET: DriversCompaniesCatsss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriversCompaniesCats == null)
            {
                return NotFound();
            }

            var driversCompaniesCat = await _context.DriversCompaniesCats.FindAsync(id);
            if (driversCompaniesCat == null)
            {
                return NotFound();
            }
            return View(driversCompaniesCat);
        }

        // POST: DriversCompaniesCatsss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,CompaniesType")] DriversCompaniesCat driversCompaniesCat)
        {
            if (id != driversCompaniesCat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driversCompaniesCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversCompaniesCatExists(driversCompaniesCat.ID))
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
            return View(driversCompaniesCat);
        }

        // GET: DriversCompaniesCatsss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriversCompaniesCats == null)
            {
                return NotFound();
            }

            var driversCompaniesCat = await _context.DriversCompaniesCats
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driversCompaniesCat == null)
            {
                return NotFound();
            }

            return View(driversCompaniesCat);
        }

        // POST: DriversCompaniesCatsss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriversCompaniesCats == null)
            {
                return Problem("Entity set 'DBContext.DriversCompaniesCats'  is null.");
            }
            var driversCompaniesCat = await _context.DriversCompaniesCats.FindAsync(id);
            if (driversCompaniesCat != null)
            {
                _context.DriversCompaniesCats.Remove(driversCompaniesCat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversCompaniesCatExists(int id)
        {
          return _context.DriversCompaniesCats.Any(e => e.ID == id);
        }
    }
}
