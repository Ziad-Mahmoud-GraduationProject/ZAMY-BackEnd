namespace ZAMY.Domain.Entities
{
    public class KitchenOwnerPhone : _BaseEntity
    {
        public int Phone { get; set; }
        public int KitchenId { get; set; }
        public  Kitchen Kitchen { get; set; }
    }
}
