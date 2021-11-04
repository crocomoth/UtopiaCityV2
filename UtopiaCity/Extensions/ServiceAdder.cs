using Microsoft.Extensions.DependencyInjection;
using UtopiaCity.Services.FireDepartment.FireIncidentReportServices;

namespace UtopiaCity.Extensions
{
    public static class ServiceAdder
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFireIncidentReportService, FireIncidentReportService>();
        }
    }
}
