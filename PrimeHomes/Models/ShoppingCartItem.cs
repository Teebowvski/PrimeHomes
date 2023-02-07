namespace PrimeHomes.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Property Property { get; set; }
        public double Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
