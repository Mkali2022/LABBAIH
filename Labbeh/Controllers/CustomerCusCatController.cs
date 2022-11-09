using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class CustomerCusCatController : Controller
    {
        private readonly ICustomerCusCatRepo _customerCusCatRepo;
        private readonly DBContext _dbContext;
        public CustomerCusCatController(DBContext dBContext, ICustomerCusCatRepo customerCusCatRepo)
        {
            _customerCusCatRepo = customerCusCatRepo;
            _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            var customerCusCat = _customerCusCatRepo.GitAllCustomerCusCat();
            return View(customerCusCat.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            CustomerCusCatVM vM = new CustomerCusCatVM
            {
                customerCategories = _dbContext.CustomerCategories.ToList(),
                customers = _dbContext.Customers.ToList(),
            };
            return View(vM);
        }

        [HttpPost]
        public IActionResult Create(CustomerCusCatVM vM, CustomerCusCat customerCusCat)
        {

            customerCusCat.CurrentDate = vM.CurrentDate;
            customerCusCat.CustomerCatID = _dbContext.CustomerCategories.Find(vM.CustomerCatID).ID;
            customerCusCat.CustomerID = _dbContext.Customers.Find(vM.CustomerID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _customerCusCatRepo.Create(customerCusCat);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _customerCusCatRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.CurrentDate + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit()
        {
            CustomerCusCatVM vM = new CustomerCusCatVM
            {
                customerCategories = _dbContext.CustomerCategories.ToList(),
                customers = _dbContext.Customers.ToList(),
            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult Edit(CustomerCusCatVM vM, CustomerCusCat customerCusCat)
        {
            customerCusCat.CurrentDate = vM.CurrentDate;
            customerCusCat.CustomerCatID = _dbContext.CustomerCategories.Find(vM.CustomerCatID).ID;
            customerCusCat.CustomerID = _dbContext.Customers.Find(vM.CustomerID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _customerCusCatRepo.Edit(customerCusCat);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _customerCusCatRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.CurrentDate + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult GetById(int id)
        {
            var customerCusCat = _customerCusCatRepo.GitCustomerCusCatById(id);
            return View(customerCusCat);
        }
    }
}
