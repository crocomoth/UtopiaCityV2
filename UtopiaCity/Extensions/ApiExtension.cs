using Microsoft.Extensions.DependencyInjection;

namespace UtopiaCity.Extensions
{
    public static class ApiExtension
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            
            return services;
        }
    }
}