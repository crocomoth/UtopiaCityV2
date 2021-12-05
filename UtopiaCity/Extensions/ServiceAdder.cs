using Microsoft.Extensions.DependencyInjection;
using UtopiaCity.Services.Business;
using UtopiaCity.Services.Business.Impl;
using UtopiaCity.Services.FireDepartment.FireIncidentReportServices;

namespace UtopiaCity.Extensions
{
    public static class ServiceAdder
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFireIncidentReportService, FireIncidentReportService>();

            services.AddBusinessServices();
        }
        
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IVacancyService, VacancyService>();

            return services;
        }
    }
}
