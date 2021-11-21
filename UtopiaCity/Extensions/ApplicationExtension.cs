using Microsoft.Extensions.DependencyInjection;
using UtopiaCity.Services.Business.Application;
using UtopiaCity.Services.Business.Application.Impl;

namespace UtopiaCity.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            #region Business

            services.AddScoped<ICompanyService, CompanyService>();

            #endregion
            
            return services;
        }
    }
}