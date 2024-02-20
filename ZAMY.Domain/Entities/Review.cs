namespace ZAMY.Domain.Entities
{
    public class Review : _BaseEntity
    {
        public DateTime ReviewDate { get; set; } 
        public string Comment { get; set; }
        public double KitchenRating { get; set; }
        public double DeliveryServiceRating { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
