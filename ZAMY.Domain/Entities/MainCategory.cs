namespace ZAMY.Domain.Entities
{
    public class MainCategory : _BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<Meal?> Meals { get; set; } = new HashSet<Meal?>();
    }
}
