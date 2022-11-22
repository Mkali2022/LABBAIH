using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class CompanyCategoryController : Controller
    {


        private readonly IDriverComCatRepo _driverComCatRepo;
        private readonly DBContext _dBContext;
        public CompanyCategoryController(IDriverComCatRepo driverComCatRepo,DBContext dBContext)
        {
            _driverComCatRepo = driverComCatRepo;
            _dBContext = dBContext;
        }
        public IActionResult Index()
        {
            var category = _driverComCatRepo.GitAllDriverComCat();
            return View(category.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat();
            return View(driversCompaniesCat);

        }
        [HttpPost]
        public IActionResult Create(DriversCompaniesCat driversCompaniesCat)
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
        public IActionResult Edit()
        {
            DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat();
            TempData.Keep();
            return View(driversCompaniesCat);
        }
        [HttpPost]
        public IActionResult Edit(DriversCompaniesCat driversCompaniesCat)
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
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
