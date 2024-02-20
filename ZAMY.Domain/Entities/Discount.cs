namespace ZAMY.Domain.Entities
{
    public class Discount : _BaseEntity
    {
        public decimal DiscountPrecent { get; set; }
        public  ICollection<Order> Orders { get; set; }=new HashSet<Order>();
    }
}
