using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labbeh.Controllers
{
    public class DriverVehiclesController : Controller
    {
        private readonly IDriverVehicleseRepo _driverVehicleseRepo;
        private readonly DBContext _dBContext;
        public DriverVehiclesController(IDriverVehicleseRepo driverVehicleseRepo, DBContext dBContext)
        {
            _driverVehicleseRepo = driverVehicleseRepo;
            _dBContext = dBContext;
        }

        public IActionResult Index()
        {
            var driver = _driverVehicleseRepo.GitAllDriverVehicle();

            return View(driver.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            DriverVehiclesVm vM = new DriverVehiclesVm
            {
                drivers = _dBContext.Drivers.ToList(),
                vehicles = _dBContext.Vehicles.ToList(),

            };
            return View(vM);
        }

        [HttpPost]
        public IActionResult Create(DriverVehiclesVm vM, DriverVehicle driverVehicle)
        {

            driverVehicle.Code = vM.Code;
            driverVehicle.UsingDate = vM.UsingDate;
            driverVehicle.DriverID = _dBContext.Drivers.Find(vM.DriverID).ID;
            driverVehicle.VehicleID = _dBContext.Vehicles.Find(vM.VehicleID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverVehicleseRepo.Create(driverVehicle);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverVehicleseRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.Code + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit()
        {
            DriverVehiclesVm vM = new DriverVehiclesVm
            {
                drivers = _dBContext.Drivers.ToList(),
                vehicles = _dBContext.Vehicles.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Edit(DriverVehiclesVm vM, DriverVehicle driverVehicle)
        {
            driverVehicle.Code = vM.Code;
            driverVehicle.UsingDate = vM.UsingDate;
            driverVehicle.DriverID = _dBContext.Drivers.Find(vM.DriverID).ID;
            driverVehicle.VehicleID = _dBContext.Vehicles.Find(vM.VehicleID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverVehicleseRepo.Edit(driverVehicle);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverVehicleseRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.Code + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult GetById(int id)
        {
            var driverVehiclese = _driverVehicleseRepo.GitDriverVehicleID(id);
            return View(driverVehiclese);
        }
    }
}
