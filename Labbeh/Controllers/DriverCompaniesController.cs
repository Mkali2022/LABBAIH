using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labbeh.Data;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.IRepository;

namespace Labbeh.Controllers
{
    public class DriverCompaniesController : Controller
    {
        public readonly IDriverComCatRepo _driverComCatRepo;
        private readonly DBContext _context;
        private readonly IDriverCompanyRepo _driverCompanyRepo;


        public DriverCompaniesController(DBContext context, IDriverComCatRepo driverComCatRepo, IDriverCompanyRepo driverCompanyRepo)
        {
            _context = context;
            _driverComCatRepo = driverComCatRepo;
           _driverCompanyRepo = driverCompanyRepo;
        }

        // GET: DriverCompanies
        public  IActionResult Index()
        {
            var company = _driverCompanyRepo.GitAllDriverCom();
            
            return View(company.ToList());
        }
        

        // GET: DriverCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.driverCompanies == null)
            {
                return NotFound();
            }

            var driverCompany = await _context.driverCompanies
                .Include(d => d.DriversCompaniesCats)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driverCompany == null)
            {
                return NotFound();
            }

            return View(driverCompany);
        }

        // GET: DriverCompanies/Create
        public IActionResult Create()
        {
            ViewData["DriverCompCatID"] = new SelectList(_context.Set<DriversCompaniesCat>(), "Id", "CompanyType");//Category to view will be select All categoryType to list
            return View();
        }

        // POST: DriverCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverCompany driverCompany)
        {
            /*
            if (ModelState.IsValid)
            {
                _context.Add(driverCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverCompCatID"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", driverCompany.DriverCompCatID);
            return View(driverCompany);
            */
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverCompanyRepo.Create(driverCompany);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverCompanyRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(driverCompany);
            }
            else
            {
                TempData["SuccessMessage"] = "" + driverCompany.CompanyName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: DriverCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            /*
            if (id == null || _context.driverCompanies == null)
            {
                return NotFound();
            }

            var driverCompany = await _context.driverCompanies.FindAsync(id);
            if (driverCompany == null)
            {
                return NotFound();
            }
            ViewData["DriverCompCatID"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", driverCompany.DriverCompCatID);
            return View(driverCompany);*/
            DriverCompany driverCompany = new DriverCompany();
            TempData.Keep();
            ViewData["categoryName"] = new SelectList(_context.Set<DriversCompaniesCat>(), "Id", "CompanyType");
            return View(driverCompany);
        }

        // POST: DriverCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverCompany driverCompany)
        {
            /*
            if (id != driverCompany.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverCompanyExists(driverCompany.ID))
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
            ViewData["DriverCompCatID"] = new SelectList(_context.DriversCompaniesCats, "ID", "ID", driverCompany.DriverCompCatID);
            return View(driverCompany);*/
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _driverCompanyRepo.Edit(driverCompany);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
                currentPage = (int)TempData["CurrentPage"];

            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverCompanyRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(driverCompany);
            }
            else
            {
                return RedirectToAction(nameof(Index));//??
            }
        }

        // GET: DriverCompanies/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.driverCompanies == null)
            {
                return NotFound();
            }

            var driverCompany = await _context.driverCompanies
                .Include(d => d.DriversCompaniesCats)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (driverCompany == null)
            {
                return NotFound();
            }

            return View(driverCompany);
        }

        // POST: DriverCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.driverCompanies == null)
            {
                return Problem("Entity set 'DBContext.driverCompanies'  is null.");
            }
            var driverCompany = await _context.driverCompanies.FindAsync(id);
            if (driverCompany != null)
            {
                _context.driverCompanies.Remove(driverCompany);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool DriverCompanyExists(int id)
        {
          return _context.driverCompanies.Any(e => e.ID == id);
        }

        ///DriverComCat
        public IActionResult CreateComCat()
        {
            DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat();
            return View(driversCompaniesCat);
        }
        [HttpPost]
        public IActionResult CreateComCat(DriversCompaniesCat driversCompaniesCat)
        {

            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _driverComCatRepo.Create(driversCompaniesCat);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverComCatRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(driversCompaniesCat);
            }
            else
            {
                TempData["SuccessMessage"] = "" + driversCompaniesCat.CompaniesType + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }

        }
        public IActionResult IndexTest()
        {
            var item = _driverComCatRepo.GitAllDriverComCat();

            return View(item.ToList());
        }
        public IActionResult GetAllCategoryCom()
        {
            var item = _driverComCatRepo.GitAllDriverComCat();

            return View(item.ToList());
        }

        public IActionResult EditCategoryCom()
        {
            DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat();
            TempData.Keep();
            return View(driversCompaniesCat);
        }
        [HttpPost]
        public IActionResult EditCategoryCom(DriversCompaniesCat driversCompaniesCat)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _driverComCatRepo.Edit(driversCompaniesCat);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
                currentPage = (int)TempData["CurrentPage"];

            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverComCatRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(driversCompaniesCat);
            }
            else
            {
                return RedirectToAction(nameof(GetAllCategoryCom), new { pg = currentPage });//??????
            }
        }
        public IActionResult GitDriverComCatByID(int id)
        {
            DriversCompaniesCat cat = _driverComCatRepo.GitDriverComCatByID(id);
            return View(cat);
        }

    }
    
}
