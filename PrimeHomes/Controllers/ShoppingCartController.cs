using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using PrimeHomes.ViewModels;
using System.Linq;

namespace PrimeHomes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShoppingCartController : Controller
    {
        private readonly IPropertyService _service;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IPropertyService service, ShoppingCart shoppingCart)
        {
            _service = service;
            _shoppingCart = shoppingCart;
        }
       
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int propertyId)
        {
            var selectedProperty = _service.Property().FirstOrDefault(x => x.Id == propertyId);
            if (selectedProperty != null)
            {
                _shoppingCart.AddToCart(selectedProperty, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int propertyId)
        {
            var selectedProperty = _service.Property().FirstOrDefault(p => p.Id == propertyId);
            if (selectedProperty != null)
            {
                _shoppingCart.RemoveFromCart(selectedProperty);
            }
            return RedirectToAction("Index");
        }
    }
}

