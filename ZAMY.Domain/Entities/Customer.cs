namespace ZAMY.Domain.Entities
{
    public class Customer : _BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = null!;
        public DateTime BirthOfDate { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; } = string.Empty;
        public  ICollection<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public  ICollection<CustomerPayment> CustomerPayments { get; set; } = new HashSet<CustomerPayment>();
        public  ICollection<CustomerPhone> CustomerPhones { get; set; } = new HashSet<CustomerPhone>();
        public  ICollection<CustomerMeal> CustomerMeals { get; set; } = new HashSet<CustomerMeal>();
        public  ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public  ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public  ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public  ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
    }
}
