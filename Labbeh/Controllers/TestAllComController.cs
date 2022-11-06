using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Models;
using Labbeh.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace Labbeh.Controllers
{
    public class TestAllComController : Controller
    {
        
        private readonly DBContext _dbContext;
        public TestAllComController(DBContext dBContext)
        {
            _dbContext = dBContext;       
        }
        public IActionResult Index()
        {
            CompanyAll vM = new CompanyAll
            {
                driversCompaniesCats = _dbContext.DriversCompaniesCats.ToList(),
                driverCompanies = _dbContext.driverCompanies.ToList(),

            };
            return View(vM);
            
        }
    }
}
