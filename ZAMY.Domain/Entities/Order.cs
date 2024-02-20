namespace ZAMY.Domain.Entities
{
    public class Order : _BaseEntity
    {
        public string PaymentMethod { get; set; }
        public decimal OrderDiscount { get; set; }
        public bool Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public int DeliveryAddressId { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
