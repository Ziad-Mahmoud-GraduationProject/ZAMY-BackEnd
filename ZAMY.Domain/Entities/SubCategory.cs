namespace ZAMY.Domain.Entities
{
    public class SubCategory : _BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
    }
}
