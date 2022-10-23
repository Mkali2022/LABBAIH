using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Labbeh.Controllers
{
    public class TestController : Controller
    {
        private readonly IDriverCompanyRepo _driverCompanyRepo;
        private readonly DBContext _dbContext;
        public TestController(DBContext dBContext, IDriverCompanyRepo driverCompanyRepo)
        {
            _driverCompanyRepo = driverCompanyRepo;
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult Test1()
        {
            CumpanyCatehoryTest vM = new CumpanyCatehoryTest
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Test1(CumpanyCatehoryTest vM, DriverCompany driverCompany)
        {
            driverCompany.Code = vM.Code;
            driverCompany.CompanyName = vM.CompanyName;
            driverCompany.Phone1 = vM.Phone1;
            driverCompany.Phone2 = vM.Phone2;
            driverCompany.CompanyAddress = vM.CompanyAddress;
            driverCompany.DriverCompCatID = _dbContext.DriversCompaniesCats.Find(vM.DriverCompCatID).ID;
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
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.CompanyName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            
        }


    }
}
