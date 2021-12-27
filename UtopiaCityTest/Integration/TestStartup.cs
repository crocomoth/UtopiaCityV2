using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using UtopiaCity.Common.Middleware;
using UtopiaCity.Data;
using UtopiaCity.Extensions;
using UtopiaCityTest.Common;

namespace UtopiaCityTest.Integration
{
    public class TestStartup
    {
        public static Action<IServiceCollection> RegisterServices;
        public static Action<IApplicationBuilder> RegisterMiddleware;

        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("UtopiaCity")).AddControllersAsServices();

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: $"Integration: {RandomUtil.GenerateRandomString(15)}"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            if (RegisterServices != null)
            {
                RegisterServices.Invoke(services);
            }

            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (RegisterMiddleware != null)
            {
                RegisterMiddleware.Invoke(app);
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
