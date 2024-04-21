namespace ZAMY.Domain.Entities
{
    public class Choice
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}
