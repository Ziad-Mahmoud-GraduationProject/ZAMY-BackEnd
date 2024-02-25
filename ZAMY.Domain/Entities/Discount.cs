namespace ZAMY.Domain.Entities
{
    public class Discount : _BaseEntity
    {
        public decimal DiscountPrecent { get; set; } = 0;
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
       
    }
}
