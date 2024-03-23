namespace ZAMY.Domain.Entities
{
    public class Kitchen : _BaseEntity
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = false;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = null!;
        public string NationalId { get; set; } =null!;
        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public DateTime BirthOfDate { get; set; }
        public Gender Gender { get; set; }
        public int LandLineNumber { get; set; }
        public double Rate { get; set; }
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<KitchenPhoto> KitchenPhotos { get; set; } = new HashSet<KitchenPhoto>();
        public ICollection<KitchenOwnerPhone> KitchenOwnerPhones { get; set; } = new HashSet<KitchenOwnerPhone>();
    }
}
