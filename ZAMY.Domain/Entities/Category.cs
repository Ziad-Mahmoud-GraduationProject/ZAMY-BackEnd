using Microsoft.EntityFrameworkCore;

namespace ZAMY.Domain.Entities
{
    [Index(nameof(Name),IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImgUrl { get; set; } = null!;

        public ICollection<Kitchen> Kitchens { get; set; } = new HashSet<Kitchen>();
    }
}
