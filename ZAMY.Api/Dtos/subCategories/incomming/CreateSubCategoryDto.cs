namespace ZAMY.Api.Dtos.subCategories.incomming
{
    public class CreateSubCategoryDto
    {
        public string Name { get; set; } = null!;
        public IFormFile Img { get; set; }
    }
}
