namespace ZAMY.Domain.Entities
{
    public class Meal : _BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public DateTime PreparationTime { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<CustomerMeal> CustomerMeals { get; set; } = new HashSet<CustomerMeal>();
        public ICollection<MealPhoto> MealPhotos { get; set; } = new HashSet<MealPhoto>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
