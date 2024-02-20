namespace ZAMY.Domain.Entities
{
    public class PaymentMethod : _BaseEntity
    {
        public string Method { get; set; }
        public  ICollection<CustomerPayment> CustomerPayments { get; set; } = new HashSet<CustomerPayment>();
    }
}
