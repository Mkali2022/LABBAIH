using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersRepo _customersRepo;
        private readonly DBContext _dBContext;
        public CustomersController(DBContext dBContext, ICustomersRepo customersRepo)
        {
            _customersRepo = customersRepo;
            _dBContext = dBContext;
        }
        public IActionResult Index()
        {
            var customer = _customersRepo.GitAllCustomer();
            return View(customer.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            Customers customers = new Customers();
            return View(customers);

        }
        [HttpPost]
        public IActionResult Create(Customers customers)
        {

            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _customersRepo.Create(customers);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _customersRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(customers);
            }
            else
            {
                TempData["SuccessMessage"] = "" + customers.CustomerName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }

        }

        public IActionResult Edit()
        {
            Customers customers = new Customers();
            TempData.Keep();
            return View(customers);
        }
        [HttpPost]
        public IActionResult Edit(Customers customers)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _customersRepo.Edit(customers);
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
                errMessage = errMessage + " " + _customersRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(customers);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult GetById(int id)
        {
            var customer = _customersRepo.GitCustomerByID(id);
            return View(customer);
        }
    }
}
