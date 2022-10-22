using Microsoft.AspNetCore.Mvc;

namespace Labbeh.Controllers
{
    public class test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
