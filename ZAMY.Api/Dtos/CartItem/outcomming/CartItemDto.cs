namespace ZAMY.Api.Dtos.CartItem.outcomming
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public int CartId { get; set; }
        public int orderId { get; set; }
    }
}
