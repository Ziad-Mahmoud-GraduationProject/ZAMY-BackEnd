namespace ZAMY.Domain.Entities
{
    public class KitchenPhoto : _BaseEntity
    {
        public string Image { get; set; }
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
    }
}
