using ZAMY.Api.Mapping;

namespace ZAMY.Api
{
    public static  class ConfigureServices
    {
        public static IServiceCollection AddMappingServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfileKitchen),
                 typeof(MappingProfileMainCategory));
            return services;
        }
    }
}
