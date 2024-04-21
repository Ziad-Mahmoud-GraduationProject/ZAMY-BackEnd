namespace ZAMY.Api.Dtos.Additions
{
    public class AdditionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = false;

        public string ImgUrl { get; set; } = null!;

        public string MealName { get; set; } = null!;
    }
}
