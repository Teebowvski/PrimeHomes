using Microsoft.AspNetCore.Mvc;

namespace PrimeHomes.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
