using System.ComponentModel.DataAnnotations;

namespace ZAMY.Domain.Entities
{
    public class Meal : _BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = false;
        [Range(1,5)]
        public double Rating { get; set; }
        public DateTime PreparationTime { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public ICollection<MealPhoto> MealPhotos { get; set; } = new HashSet<MealPhoto>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
