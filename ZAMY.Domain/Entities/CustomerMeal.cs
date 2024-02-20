namespace ZAMY.Domain.Entities
{
    public class CustomerMeal : _BaseEntity
    {
        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }
        public int MealId { get; set; }
        public  Meal Meal { get; set; }
    }
}
