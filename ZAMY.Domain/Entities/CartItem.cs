namespace ZAMY.Domain.Entities
{
    public class CartItem : _BaseEntity
    {
        public int Quantity { get; set; } = 1;
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
