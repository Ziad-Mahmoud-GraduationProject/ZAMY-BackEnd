namespace ZAMY.Domain.Entities
{
    public class Order : _BaseEntity
    {
        public string PaymentMethod { get; set; }
        public Status Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
