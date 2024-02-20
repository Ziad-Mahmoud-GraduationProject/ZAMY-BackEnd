namespace ZAMY.Domain.Entities
{
    public class MealPhoto : _BaseEntity
    {
        public string Image { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get;set; }
    }
}
