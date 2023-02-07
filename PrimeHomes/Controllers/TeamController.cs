using Microsoft.AspNetCore.Mvc;

namespace PrimeHomes.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
