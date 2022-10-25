using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.Repository;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class ContractCompanyController : Controller
    {
        private readonly IDriverCompContractRepo _driverCompContractRepo;
        private readonly DBContext _dbContext;
        public ContractCompanyController(IDriverCompContractRepo driverCompContractRepo, DBContext dbContext)
        {
            _driverCompContractRepo = driverCompContractRepo;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var contract = _driverCompContractRepo.GitAllDriverCompContract();

            return View(contract.ToList());
        }
        [HttpGet]
        public IActionResult CreateComContract()
        {
            CompanyContractcs vM = new CompanyContractcs
            {
                driverCompanies = _dbContext.driverCompanies.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult CreateComContract(CompanyContractcs vM, DriverCompContract driverCompContract)
        {

            driverCompContract.Code = vM.Code;
            driverCompContract.OwnerName = vM.OwnerName;
            driverCompContract.OrganizationAddress = vM.OrganizationAddress;
            driverCompContract.DateFrom = vM.DateFrom;
            driverCompContract.DateTo = vM.DateTo;
            driverCompContract.Phone1 = vM.Phone1;
            driverCompContract.Phone2 = vM.Phone2;
            driverCompContract.DriverCompID = _dbContext.driverCompanies.Find(vM.DriverCompID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverCompContractRepo.Create(driverCompContract);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverCompContractRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.OwnerName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }

        }
        public IActionResult EditCompany()
        {
            CompanyContractcs vM = new CompanyContractcs
            {

                driverCompanies = _dbContext.driverCompanies.ToList(),

            };
            return View(vM);
        }
        [HttpPost]
        public IActionResult EditCompany(CompanyContractcs vM, DriverCompContract driverCompContract)
        {
            driverCompContract.Code = vM.Code;
            driverCompContract.OwnerName = vM.OwnerName;
            driverCompContract.OrganizationAddress = vM.OrganizationAddress;
            driverCompContract.DateFrom = vM.DateFrom;
            driverCompContract.DateTo = vM.DateTo;
            driverCompContract.Phone1 = vM.Phone1;
            driverCompContract.Phone2 = vM.Phone2;
            driverCompContract.DriverCompID = _dbContext.driverCompanies.Find(vM.DriverCompID).ID;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bolret = _driverCompContractRepo.Edit(driverCompContract);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + " " + _driverCompContractRepo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(vM);
            }
            else
            {
                TempData["SuccessMessage"] = "" + vM.OwnerName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult GetAllCompany()
        {
            CompanyContractcs vM = new CompanyContractcs
            {
                driverCompanies = _dbContext.driverCompanies.ToList(),

            };
            return View(vM);
        }

        public IActionResult GetById(int id)
        {
            var contract = _driverCompContractRepo.GitDriverCompContractByID(id);

            return View(contract);
        }

    }
}
