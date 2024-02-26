namespace ZAMY.Domain.Entities
{
    public class Customer : _BaseEntity
    {
        public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public ICollection<CustomerPayment> CustomerPayments { get; set; } = new HashSet<CustomerPayment>();
        public ICollection<CustomerPhone> CustomerPhones { get; set; } = new HashSet<CustomerPhone>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public Cart Cart { get; set; } 
    }
}
