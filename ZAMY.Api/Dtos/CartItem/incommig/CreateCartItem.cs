namespace ZAMY.Api.Dtos.CartItem.incommig
{
    public class CreateCartItem
    {
        public int Quantity { get; set; } 
        public int MealId { get; set; }
        public int CartId { get; set; }
        public int orderId { get; set; }
    }
}
