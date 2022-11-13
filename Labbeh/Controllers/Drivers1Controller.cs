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
    public class Drivers1Controller : Controller
    {
        private readonly DBContext _context;

        public Drivers1Controller(DBContext context)
        {
            _context = context;
        }

        // GET: Drivers1
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.drivers.Include(d => d.DriverCompany).Include(d => d.DriversCompaniesCat);
            return View(await dBContext.ToListAsync());
        }

        // GET: Drivers1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.drivers
                .Include(d => d.DriverCompany)
                .Include(d => d.DriversCompaniesCat)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // GET: Drivers1/Create
        public IActionResult Create()
        {
            ViewData["DriverCompanyId"] = new SelectList(_context.driverCompanies, "ID", "ID");
            ViewData["DriverTTypeId"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID");
            return View();
        }

        // POST: Drivers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DriverCode,DriverName,DriverPhone,LatitudeDefault,LongtitudeDefault,DriverEmail,DriverTTypeId,DriverCompanyId,Status")] Drivers drivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverCompanyId"] = new SelectList(_context.driverCompanies, "ID", "ID", drivers.DriverCompanyId);
            ViewData["DriverTTypeId"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", drivers.DriverTTypeId);
            return View(drivers);
        }

        // GET: Drivers1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }
            ViewData["DriverCompanyId"] = new SelectList(_context.driverCompanies, "ID", "ID", drivers.DriverCompanyId);
            ViewData["DriverTTypeId"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", drivers.DriverTTypeId);
            return View(drivers);
        }

        // POST: Drivers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DriverCode,DriverName,DriverPhone,LatitudeDefault,LongtitudeDefault,DriverEmail,DriverTTypeId,DriverCompanyId,Status")] Drivers drivers)
        {
            if (id != drivers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversExists(drivers.ID))
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
            ViewData["DriverCompanyId"] = new SelectList(_context.driverCompanies, "ID", "ID", drivers.DriverCompanyId);
            ViewData["DriverTTypeId"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", drivers.DriverTTypeId);
            return View(drivers);
        }

        // GET: Drivers1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.drivers
                .Include(d => d.DriverCompany)
                .Include(d => d.DriversCompaniesCat)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // POST: Drivers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.drivers == null)
            {
                return Problem("Entity set 'DBContext.drivers'  is null.");
            }
            var drivers = await _context.drivers.FindAsync(id);
            if (drivers != null)
            {
                _context.drivers.Remove(drivers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversExists(int id)
        {
          return _context.drivers.Any(e => e.ID == id);
        }
    }
}
