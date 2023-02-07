using Microsoft.AspNetCore.Mvc;

namespace PrimeHomes.Controllers
{
    public class HomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
