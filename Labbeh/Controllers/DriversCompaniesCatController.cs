using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Labbeh.Controllers;
[Authorize]
public class DriversCompaniesCatController : Controller
{
    public readonly IDriverComCatRepo _driverComCatRepo;
    public readonly IDriverCompanyRepo _driverCompanyRepo;
    public readonly IDriverCompContractRepo _driverCompContractRepo;
    public readonly IDriverRepo _driverRepo; 
    private readonly DBContext context;
    public DriversCompaniesCatController(IDriverComCatRepo driverComCatRepo, IDriverCompanyRepo driverCompanyRepo,IDriverRepo driverRepo)
    {
        _driverComCatRepo = driverComCatRepo;
        _driverCompanyRepo = driverCompanyRepo;
        _driverRepo = driverRepo;
        
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult categoryCompanyIndex()
    {
        var categoryCompany = _driverComCatRepo.GitAllDriverComCat;
        return View(categoryCompany);
    }
    public IActionResult Create()
    {
        DriversCompaniesCat driversCompaniesCat= new DriversCompaniesCat();
        return View(driversCompaniesCat);
    }
    [HttpPost]
    public IActionResult Create(DriversCompaniesCat driversCompaniesCat)
    {
        bool bolret = false;
        string errMessage = "";
        try
        {
            bolret = _driverComCatRepo.Create(driversCompaniesCat);
            
        }
        catch(Exception ex)
        {
            errMessage = errMessage + " " + ex.Message;
        }
        if (bolret == false)
        {
            errMessage =errMessage+" "+ _driverComCatRepo.GetErrors();
            TempData["ErrorMessage"] = errMessage;
            ModelState.AddModelError("", errMessage);
            return View(driversCompaniesCat);
        }
        else
        {
            TempData["SuccessMessage"] = "" + driversCompaniesCat.CompaniesType + " Created Successfully";
            return RedirectToAction(nameof(Index));
        }
        
    }
    public IActionResult Edit()
    {
        DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat();
        TempData.Keep();
        return View(driversCompaniesCat);
    }
    [HttpPost]
    public IActionResult Edit (DriversCompaniesCat driversCompaniesCat)
    {
        bool bolret = false;
        string errMessage = "";
        try
        {
            bolret = _driverComCatRepo.Edit(driversCompaniesCat);

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
            errMessage = errMessage + " " + _driverComCatRepo.GetErrors();
            TempData["ErrorMessage"] = errMessage;
            ModelState.AddModelError("", errMessage);
            return View(driversCompaniesCat);
        }
        else
        {
            return RedirectToAction(nameof(categoryCompanyIndex), new { pg = currentPage }) ;//??????
        }
    }
    public IActionResult GitDriverComCatByID(int id)
    {
        DriversCompaniesCat cat = _driverComCatRepo.GitDriverComCatByID(id);
        return View(cat);
    }

    ////////////End DriverCompanyCat


    ///////////Company

    public IActionResult CompanyIndex()
    {
        var company = _driverCompanyRepo.GitAllDriverCom();
        return View(company);
    }
    public IActionResult CreateCompany()
    {
        DriverCompany driverCompany = new DriverCompany();
        /*DriversCompaniesCat driversCompaniesCat = new DriversCompaniesCat;
        List<SelectListItem> categoryName =
                    context.DriversCompaniesCats.OrderBy(n => n.CompaniesType).Select(n =>
                    new SelectListItem
                    {
                        Value = n.ID.ToString(),
                        Text = n.CompaniesType
                    }).ToList();
        driversCompaniesCat.CompaniesType = categoryName;*///Test => error CompaniesType must be ToString()!!!
        ViewData["categoryName"] = new SelectList(context.Set<DriversCompaniesCat>(), "Id", "CompanyType");//Category to view will be select All categoryType to list
        return View(driverCompany);
    }
    [HttpPost]
    public IActionResult CreateCompany(DriverCompany driverCompany)
    {
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
            return View(driverCompany);
        }
        else
        {
            TempData["SuccessMessage"] = "" + driverCompany.CompanyName + " Created Successfully";
            return RedirectToAction(nameof(Index));
        }

    }

    public IActionResult EditCompany()
    {
        DriverCompany driverCompany = new DriverCompany();
        TempData.Keep();
        ViewData["categoryName"] = new SelectList(context.Set<DriversCompaniesCat>(), "Id", "CompanyType");
        return View(driverCompany);
    }
    [HttpPost]
    public IActionResult EditCompany(DriverCompany driverCompany)

    {
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
        int currentPage = 1;
        if (TempData["CurrentPage"] != null)
            currentPage = (int)TempData["CurrentPage"];

        if (bolret == false)
        {
            errMessage = errMessage + " " + _driverCompanyRepo.GetErrors();
            TempData["ErrorMessage"] = errMessage;
            ModelState.AddModelError("", errMessage);
            return View(driverCompany);
        }
        else
        {
            return RedirectToAction(nameof(CompanyIndex), new { pg = currentPage });//??
        }
    }
    public IActionResult GitDriverComByID(int id)
    {
        DriverCompany com = _driverCompanyRepo.GitDriverComByID(id);
        return View(com);
    }

    ///////End Company
    //////DriverCompanyCategory
    public IActionResult CompanyContractIndex()
    {
        var companyCon = _driverCompContractRepo.GitAllDriverCompContract();
        return View(companyCon);
    }
    public IActionResult CreateCompanyContract()
    {
        DriverCompContract driverCompContract = new DriverCompContract();

        return View(driverCompContract);
    }
    [HttpPost]
    public IActionResult CreateCompanyContract(DriverCompContract driverCompContract)
    {
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
            return View(driverCompContract);
        }
        else
        {
            TempData["SuccessMessage"] = "" + driverCompContract.Code + " Created Successfully";
            return RedirectToAction(nameof(CompanyContractIndex));
        }

    }
    public IActionResult EditCompanyCon()
    {
        DriverCompContract driverCompContract = new DriverCompContract();
        TempData.Keep();
        return View(driverCompContract);
    }
    [HttpPost]
    public IActionResult EditCompanyCon(DriverCompContract driverCompContract)

    {
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
        int currentPage = 1;
        if (TempData["CurrentPage"] != null)
            currentPage = (int)TempData["CurrentPage"];

        if (bolret == false)
        {
            errMessage = errMessage + " " + _driverCompContractRepo.GetErrors();
            TempData["ErrorMessage"] = errMessage;
            ModelState.AddModelError("", errMessage);
            return View(driverCompContract);
        }
        else
        {
            return RedirectToAction(nameof(CompanyContractIndex), new { pg = currentPage });//??
        }
    }
    public IActionResult GitCompanyConByID(int id)
    {
        DriverCompContract con = _driverCompContractRepo.GitDriverCompContractByID(id);
        return View(con);
    }

    //////DriverCompanyCategory

    //////Drivers
    public IActionResult CreateDriver()
    {
        Drivers company = new Drivers();
        ViewData["CompanyName"] = new SelectList(context.Set<DriverCompany>(), "Id", "CompanyName");//Category to view will be select All CompanyName to list
        return View(company);
    }
    
    
}
