
namespace ZAMY.Api.Dtos.Review.incomming
{
    public class CreateReview
    {
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public string? Comment { get; set; }
        [Range(1, 5)]
        public double KitchenRating { get; set; }
        [Range(1, 5)]
        public double DeliveryServiceRating { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
