using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class CustomerCategoryController : Controller
    {
        private readonly ICustomerCategoryRepo _customerCategoryRepo;
        private readonly DBContext _dBContext;
        public CustomerCategoryController(DBContext dBContext, ICustomerCategoryRepo customerCategoryRepo)
        {
            _customerCategoryRepo = customerCategoryRepo;
            _dBContext = dBContext;
        }
        public IActionResult Index()
        {
            var customerCat= _customerCategoryRepo.GitAllCustomerCat();
            return View(customerCat.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            CustomerCategory customerCategory = new CustomerCategory();
            return View(customerCategory);

        }
        [HttpPost]
        public IActionResult Create(CustomerCategory customerCategory)
        {

            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _customerCategoryRepo.Create(customerCategory);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _customerCategoryRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(customerCategory);
            }
            else
            {
                TempData["SuccessMessage"] = "" + customerCategory.CategoyName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }

        }

        public IActionResult Edit()
        {
            CustomerCategory customerCategory = new CustomerCategory();
            TempData.Keep();
            return View(customerCategory);
        }
        [HttpPost]
        public IActionResult Edit(CustomerCategory customerCategory)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                bolret = _customerCategoryRepo.Edit(customerCategory);

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
                errMessage = errMessage + " " + _customerCategoryRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(customerCategory);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult GetById(int id)
        {
            var customerCat = _customerCategoryRepo.GitCustomerCatByID(id);
            return View(customerCat);
        }
    }
}
