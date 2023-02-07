using Microsoft.AspNetCore.Mvc;

namespace PrimeHomes.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Invoiceprint()
        {
            return View();
        }
    }
}
