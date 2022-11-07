using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class DriversController : Controller
    {
        private readonly IDriverRepo _driverRepo;
        private readonly DBContext _dbContext;


        public DriversController(DBContext dBContext, IDriverRepo driverRepo)
        {
            _driverRepo = driverRepo;
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            var driver = _driverRepo.GitAllDriver();
            return View(driver.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            DriversVm vM = new DriversVm
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),
                driverCompanies = _dbContext.driverCompanies.ToList(),
            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Create(DriversVm vM, Drivers driver)
        {

            driver.DriverCode = vM.DriverCode;
            driver.DriverName = vM.DriverName;
            driver.DriverPhone = vM.DriverPhone;
            driver.LatitudeDefault = vM.LatitudeDefault;
            driver.LongtitudeDefault = vM.LongtitudeDefault;
            driver.DriverEmail = vM.DriverEmail;
            driver.Status = vM.Status;
            driver.DriverTTypeId = _dbContext.DriversCompaniesCats.Find(vM.DriverTTypeId).ID;
            driver.DriverCompanyId = _dbContext.driverCompanies.Find(vM.DriverCompanyId).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _driverRepo.Create(driver);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.DriverName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Edit()
        {
            DriversVm vM = new DriversVm
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),
                driverCompanies = _dbContext.driverCompanies.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Edit(DriversVm vM, Drivers driver)
        {
            driver.DriverCode = vM.DriverCode;
            driver.DriverName = vM.DriverName;
            driver.DriverPhone = vM.DriverPhone;
            driver.LatitudeDefault = vM.LatitudeDefault;
            driver.LongtitudeDefault = vM.LongtitudeDefault;
            driver.DriverEmail = vM.DriverEmail;
            driver.Status = vM.Status;
            driver.DriverTTypeId = _dbContext.DriversCompaniesCats.Find(vM.DriverTTypeId).ID;
            driver.DriverCompanyId = _dbContext.driverCompanies.Find(vM.DriverCompanyId).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverRepo.Edit(driver);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.DriverName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult GetById(int id)
        {
            var driver = _driverRepo.GitDriver(id);
            return View(driver);
        }
    }
}
