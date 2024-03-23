using ZAMY.Domain.Enums;

namespace ZAMY.Api.Dtos.Kitchen.outcoming
{
    public class KitchenDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public int LandLineNumber { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public double Rate { get; set; }
    }
}
