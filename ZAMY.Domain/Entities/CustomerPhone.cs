namespace ZAMY.Domain.Entities
{
    public class CustomerPhone : _BaseEntity
    {
        public int Phone { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
