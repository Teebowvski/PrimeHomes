using PrimeHomes.Models;

namespace PrimeHomes.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set; }

        public Order Order { get; set; }
    }
}
