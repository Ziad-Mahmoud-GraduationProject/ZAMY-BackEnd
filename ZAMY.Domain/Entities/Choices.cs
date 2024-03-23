namespace ZAMY.Domain.Entities
{
    public class Choices
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public Meal Meal { get; set; }
    }
}
