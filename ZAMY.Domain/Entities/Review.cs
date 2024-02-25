using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class Review : _BaseEntity
    {
        public DateTime ReviewDate { get; set; } 
        public string? Comment { get; set; }
        [Range(1, 5)]
        public double KitchenRating { get; set; }
        [Range(1,5)]
        public double DeliveryServiceRating { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
