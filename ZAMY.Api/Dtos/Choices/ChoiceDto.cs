namespace ZAMY.Api.Dtos.Choices
{
    public class ChoiceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public string MealName { get; set; } = null!;
    }
}
