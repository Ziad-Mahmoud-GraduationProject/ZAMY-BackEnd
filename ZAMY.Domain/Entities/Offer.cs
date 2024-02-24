namespace ZAMY.Domain.Entities
{
    public class Offer : _BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
