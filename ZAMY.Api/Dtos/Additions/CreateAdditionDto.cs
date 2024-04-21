namespace ZAMY.Api.Dtos.Additions
{
    public class CreateAdditionDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = false;

        public IFormFile Img{ get; set; } = null!;

        public int MealId { get; set; }
    }
}
