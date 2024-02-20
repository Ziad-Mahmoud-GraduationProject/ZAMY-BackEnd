namespace ZAMY.Domain.Entities
{
    public class CartItem : _BaseEntity
    {
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
