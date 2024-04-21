using ZAMY.Application.Services;
using ZAMY.Application.Services.Additions;
using ZAMY.Application.Services.CartItems;
using ZAMY.Application.Services.Categories;
using ZAMY.Application.Services.KitchenOwnerPhones;
using ZAMY.Application.Services.KitchenPhotos;
using ZAMY.Application.Services.Kitchens;
using ZAMY.Application.Services.MainCategories;
using ZAMY.Application.Services.Orders;
using ZAMY.Application.Services.Photo;
using ZAMY.Application.Services.Reviews;
using ZAMY.Application.Services.SubCategories;

namespace ZAMY.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionsServices, AdditionsServices>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMainCategoryService, MainCategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IKitchenService, KitchenService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IKitchenOwnerPhoneService, KitchenOwnerPhoneService>();
            //services.AddScoped<ITokenServices, TokenServices>();
            return services;
        }
    }
}
