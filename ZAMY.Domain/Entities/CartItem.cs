namespace ZAMY.Domain.Entities
{
    public class CartItem : _BaseEntity
    {
        public int Quantity { get; set; } = 0;
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}
