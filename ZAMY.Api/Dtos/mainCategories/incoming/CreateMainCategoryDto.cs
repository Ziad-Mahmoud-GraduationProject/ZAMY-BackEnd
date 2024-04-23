namespace ZAMY.Api.Dtos.mainCategories.incoming
{
    public class CreateMainCategoryDto
    {
        public string Name { get; set; } = null!;
        public IFormFile Img { get; set; }

    }
}
