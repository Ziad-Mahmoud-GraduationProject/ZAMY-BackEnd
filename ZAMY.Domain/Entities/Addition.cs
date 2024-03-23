namespace ZAMY.Domain.Entities
{
    public class Addition
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = false;

        public string ImgUrl { get; set; } = null!;

        public Meal Meal { get; set; }
    }
}
