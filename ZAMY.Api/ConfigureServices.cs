using FluentValidation;
using FluentValidation.AspNetCore;
using ZAMY.Api.Mapping;
using ZAMY.Api.Validation;

namespace ZAMY.Api
{
    public static  class ConfigureServices
    {
        public static IServiceCollection AddMappingServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddValidatorsFromAssemblyContaining<Program>();

            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
