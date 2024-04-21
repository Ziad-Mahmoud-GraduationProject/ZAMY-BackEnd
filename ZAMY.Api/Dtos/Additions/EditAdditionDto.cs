namespace ZAMY.Api.Dtos.Additions
{
    public class EditAdditionDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = false;

        public IFormFile? Img { get; set; }

        public int MealId { get; set; }
    }
}
