using Microsoft.AspNetCore.Mvc;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using System.Threading.Tasks;

namespace PrimeHomes.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly ShoppingCart _shopppingCart;
        public OrderController(ShoppingCart shopppingCart, IOrderService service)
        {
            _shopppingCart = shopppingCart;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _service.GetAllAsync();
            return View(data);
        }
        //public IActionResult Checkout(Order order)
        //{
        //    if ( _shopppingCart.ShoppingCartItems  == null)
        //    {
        //        ModelState.AddModelError("", "Your cart is empty, add a property or two");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _service.CreateOrder(order);
        //        _shopppingCart.ClearCart();
        //        return RedirectToAction("CheckoutComplete");
        //    }
        //    return View(order);
            
        
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your purchase :)";
            return View();
        }
        public IActionResult Checkout()
        {
            
            return View();
        }
    }
}
