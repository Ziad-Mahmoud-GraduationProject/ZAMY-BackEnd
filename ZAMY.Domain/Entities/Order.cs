namespace ZAMY.Domain.Entities
{
    public class Order : _BaseEntity
    {
        public string PaymentMethod { get; set; }
        public Status Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
