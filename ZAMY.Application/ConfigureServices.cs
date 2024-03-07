using ZAMY.Application.Services.CartItems;
using ZAMY.Application.Services.KitchenPhotos;
using ZAMY.Application.Services.Kitchens;
using ZAMY.Application.Services.MainCategories;
using ZAMY.Application.Services.SubCategories;

namespace ZAMY.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMainCategoryService, MainCategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IKitchenService, KitchenService>();
            services.AddScoped<ICartItemService, CartItemService>();
            return services;
        }
    }
}
