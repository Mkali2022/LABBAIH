using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class DriverContractController : Controller
    {
        private readonly IDriverContractRepo _driverContractRepo;
        private readonly DBContext _dbContext;
        public DriverContractController(IDriverContractRepo driverContractRepo, DBContext dBContext)
        {
            _dbContext = dBContext;
            _driverContractRepo = driverContractRepo;
        }
        public IActionResult Index()
        {
            var driverCon = _driverContractRepo.GitAllDriverContract();
            return View(driverCon.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            DriversContractVM vM = new DriversContractVM
            {
                drivers = _dbContext.drivers.ToList(),
                 
            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Create(DriversContractVM vM, DriversContract driversContract)
        {

            driversContract.Code = vM.Code;
            driversContract.ContractDetaill = vM.ContractDetaill;
            driversContract.DateFrom = vM.DateFrom;
            driversContract.DateTo = vM.DateTo;
            driversContract.DriverName = vM.DriverName;
            driversContract.DriverId = _dbContext.drivers.Find(vM.DriverId).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _driverContractRepo.Create(driversContract);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverContractRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.DriverName + "Contract Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Edit()
        {
            DriversContractVM vM = new DriversContractVM
            {
                drivers = _dbContext.drivers.ToList(),

            };
            return View(vM);
        }

        [HttpPost]
        public IActionResult Edit(DriversContractVM vM, DriversContract driversContract)
        {
            driversContract.Code = vM.Code;
            driversContract.ContractDetaill = vM.ContractDetaill;
            driversContract.DateFrom = vM.DateFrom;
            driversContract.DateTo = vM.DateTo;
            driversContract.DriverName = vM.DriverName;
            driversContract.DriverId = _dbContext.drivers.Find(vM.DriverId).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverContractRepo.Edit(driversContract);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverContractRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.DriverName + "Contract Edit Successfully";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult GetById(int id)
        {
            var driverContract = _driverContractRepo.GitDriversContractById(id);
            return View(driverContract);
        }

    }
}
