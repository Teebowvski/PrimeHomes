namespace PrimeHomes.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PropertyId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public virtual Property Property { get; set; }
        public virtual Order order { get; set; }
    }
}
