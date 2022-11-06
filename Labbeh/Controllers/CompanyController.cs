using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using NuGet.Versioning;

namespace Labbeh.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IDriverCompanyRepo _driverCompanyRepo;
        private readonly DBContext _dbContext;
       
        
        public CompanyController(DBContext dBContext, IDriverCompanyRepo driverCompanyRepo)
        {
            _driverCompanyRepo = driverCompanyRepo;
            _dbContext = dBContext;
           
            
        }
        public IActionResult Index()
        {

            var company = _driverCompanyRepo.GitAllDriverCom();

            return View(company.ToList());
        }
        public IActionResult GetAllCompany()
        {
            CompanyCategory vM = new CompanyCategory
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),

            };
            return View(vM);
        }
        [HttpGet]
        public IActionResult CreateCompany()
        {
            CompanyCategory vM = new CompanyCategory
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult CreateCompany(CompanyCategory vM, DriverCompany driverCompany)
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
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.CompanyName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            
        }

        public IActionResult EditCompany()
        {
            CompanyCategory vM = new CompanyCategory
            {
                
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult EditCompany(CompanyCategory vM, DriverCompany driverCompany)
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

                bolret = _driverCompanyRepo.Edit(driverCompany);

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

        public JsonResult GetNames()
        {
            var names=new string[3]
            {
                   "Clara",
                    "marc",
                    "Jude"
            };
            return new JsonResult(Ok(names));
        }
        [HttpPost]
        public JsonResult PostName(string name)
        {
            return new JsonResult(Ok());
        }


    }
}
