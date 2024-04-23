using Authentication.Authorization.Helper.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZAMY.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Addition> Additions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<KitchenPhoto> KitchenPhotos { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPhoto> MealPhotos { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
