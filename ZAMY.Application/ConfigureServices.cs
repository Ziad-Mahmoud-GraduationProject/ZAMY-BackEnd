using ZAMY.Application.Services.MainCategories;

namespace ZAMY.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMainCategoryService, MainCategoryService>();

            return services;
        }
    }
}
