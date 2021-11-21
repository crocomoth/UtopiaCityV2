using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UtopiaCity.Services.Business.Application;
using UtopiaCity.Services.Business.Infrastructure.Cloudinary;

namespace UtopiaCity.Extensions.InfrastructureLayer
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Cloudinary

            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IPictureService, PictureService>();
            
            #endregion
            
            return services;
        }
    }
}