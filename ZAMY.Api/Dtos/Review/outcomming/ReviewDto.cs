
namespace ZAMY.Api.Dtos.Review.outcomming
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public string? Comment { get; set; }
        public double KitchenRating { get; set; }
        public double DeliveryServiceRating { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
