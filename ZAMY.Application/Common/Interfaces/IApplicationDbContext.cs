using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAMY.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAddress> CustomerAddresses { get; set; }
        DbSet<CustomerPayment> CustomerPayments { get; set; }
        DbSet<CustomerPhone> CustomerPhones { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Kitchen> Kitchens { get; set; }
        DbSet<MainCategory> MainCategories { get; set; }
        DbSet<Meal> Meals { get; set; }
        DbSet<MealPhoto> MealPhotos { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<PaymentMethod> PaymentMethods { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }

        int SaveChanges();
    }
}
