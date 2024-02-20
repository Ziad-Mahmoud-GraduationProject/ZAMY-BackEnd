using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Domain.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public DateTime PreparationTime { get; set; }
        public string Ingredients { get; set; }
        public int KitchenId { get; set; }
        public int MainCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int OrderId { get; set; }
        public virtual Kitchen Kitchen { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<CustomerMeal> CustomerMeals { get; set; } = new HashSet<CustomerMeal>();
        public virtual ICollection<MealPhoto> MealPhotos { get; set; } = new HashSet<MealPhoto>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
