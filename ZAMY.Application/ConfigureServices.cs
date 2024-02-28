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
            return services;
        }
    }
}
