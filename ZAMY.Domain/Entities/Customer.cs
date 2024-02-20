using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAMY.Domain.Enums;

namespace ZAMY.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } 
        public DateOnly BirthOfDate { get; set; }
        public Gender? Gender { get; set; }
        public string URLPhoto { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new HashSet<CustomerPayment>();
        public virtual ICollection<CustomerPhone> CustomerPhones { get; set; } = new HashSet<CustomerPhone>();
        public virtual ICollection<CustomerMeal> CustomerMeals { get; set; } = new HashSet<CustomerMeal>();
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
    }
}
