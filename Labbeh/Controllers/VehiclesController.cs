using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehiclesRepo _vehiclesRepo;
        private readonly DBContext _dBContext;
        public VehiclesController(IVehiclesRepo vehiclesRepo,DBContext dBContext)
        {
            _dBContext = dBContext;
            _vehiclesRepo = vehiclesRepo;
        }
        public IActionResult Index()
        {
            var vehicles = _vehiclesRepo.GitAllVehicles();

            return View(vehicles.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            Vehicles vehicles = new Vehicles();
            return View(vehicles);
        }

        [HttpPost]
        public IActionResult Create(Vehicles vehicles)
        {

            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _vehiclesRepo.Create(vehicles);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _vehiclesRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vehicles);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vehicles.VehicleName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }

        }

        public IActionResult Edit()
        {
            Vehicles vehicles = new Vehicles();
            TempData.Keep();
            return View(vehicles);
        }
        [HttpPost]
        public IActionResult Edit(Vehicles vehicles)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _vehiclesRepo.Edit(vehicles);

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
                errMessage = errMessage + " " + _vehiclesRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vehicles);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult GetById(int id)
        {
            var vehicles = _vehiclesRepo.GitVehiclesByID(id);
            return View(vehicles);
        }
    }
}
