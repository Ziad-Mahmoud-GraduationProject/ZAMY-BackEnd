namespace ZAMY.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Cart> Carts { get; }
        IBaseRepository<CartItem> CartItems { get; }
        IBaseRepository<Customer> Customers { get; }
        IBaseRepository<CustomerAddress> CustomerAddresses { get; }
        IBaseRepository<CustomerPayment> CustomerPayments { get; }
        IBaseRepository<CustomerPhone> CustomerPhones { get; }
        IBaseRepository<Discount> Discounts { get; }
        IBaseRepository<Kitchen> Kitchens { get; }
        IBaseRepository<KitchenOwnerPhone> KitchenOwnerPhones { get; }
        IBaseRepository<KitchenPhoto> KitchenPhotos { get; }
        IBaseRepository<MainCategory> MainCategories { get; }
        IBaseRepository<Meal> Meals { get; }
        IBaseRepository<MealPhoto> MealPhotos { get; }
        IBaseRepository<Order> Orders { get; }
        IBaseRepository<Payment> Payments { get; }
        IBaseRepository<PaymentMethod> PaymentMethods { get; }
        IBaseRepository<Review> Reviews { get; }
        IBaseRepository<SubCategory> SubCategories { get; }

        int Complete();

    }
}
