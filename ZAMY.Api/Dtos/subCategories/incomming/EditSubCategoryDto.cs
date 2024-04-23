namespace ZAMY.Api.Dtos.subCategories.incomming
{
    public class EditSubCategoryDto
    {
        public string Name { get; set; } = null!;
        public IFormFile Img { get; set; }
    }
}
