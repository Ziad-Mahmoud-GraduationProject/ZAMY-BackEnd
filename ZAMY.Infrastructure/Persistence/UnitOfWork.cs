namespace ZAMY.Infrastructure.Persistence
{
    public class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
    {
        public IBaseRepository<Cart> Carts => new BaseRepository<Cart>(_context);

        public IBaseRepository<CartItem> CartItems => new BaseRepository<CartItem>(_context);

        public IBaseRepository<Customer> Customers => new BaseRepository<Customer>(_context);

        public IBaseRepository<CustomerAddress> CustomerAddresses => new BaseRepository<CustomerAddress>(_context);

        public IBaseRepository<CustomerPayment> CustomerPayments => new BaseRepository<CustomerPayment>(_context);

        public IBaseRepository<CustomerPhone> CustomerPhones => new BaseRepository<CustomerPhone>(_context);

        public IBaseRepository<Discount> Discounts => new BaseRepository<Discount>(_context);

        public IBaseRepository<Kitchen> Kitchens => new BaseRepository<Kitchen>(_context);

        public IBaseRepository<KitchenOwnerPhone> KitchenOwnerPhones => new BaseRepository<KitchenOwnerPhone>(_context);

        public IBaseRepository<KitchenPhoto> KitchenPhotos => new BaseRepository<KitchenPhoto>(_context);

        public IBaseRepository<MainCategory> MainCategories => new BaseRepository<MainCategory>(_context);

        public IBaseRepository<Meal> Meals => new BaseRepository<Meal>(_context);

        public IBaseRepository<MealPhoto> MealPhotos => new BaseRepository<MealPhoto>(_context);

        public IBaseRepository<Order> Orders => new BaseRepository<Order>(_context);

        public IBaseRepository<Payment> Payments => new BaseRepository<Payment>(_context);

        public IBaseRepository<PaymentMethod> PaymentMethods => new BaseRepository<PaymentMethod>(_context);

        public IBaseRepository<Review> Reviews => new BaseRepository<Review>(_context);

        public IBaseRepository<SubCategory> SubCategories => new BaseRepository<SubCategory>(_context);

        public int Complete()
        {
           return  _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
