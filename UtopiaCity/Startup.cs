using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using UtopiaCity.Common;
using UtopiaCity.Common.Extensions;
using UtopiaCity.Common.Middleware;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Extensions;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;

namespace UtopiaCity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region Services

            services.AddSingleton<GenericDataProvider<EmergencyReport>, GenericDataProvider<EmergencyReport>>();
            services.AddScoped<EmergencyReportService, EmergencyReportService>();

            #endregion

            services.Configure<AppConfig>(Configuration.GetSection(AppConfig.Name));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            var appConfig = Configuration.GetSection(AppConfig.Name).Get<AppConfig>();
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add(Constants.Cache.Caching, new CacheProfile()
                {
                    Duration = appConfig?.CacheExpiration ?? 300,
                    Location = ResponseCacheLocation.Any
                });
                options.CacheProfiles.Add(Constants.Cache.NonCaching, new CacheProfile()
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });
            });

            services.AddServices();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var appConfig = Configuration.GetSection(AppConfig.Name).Get<AppConfig>();
            if (appConfig != null)
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DbInitializer.RegisterSubDbInitializers();

                    if (appConfig.ClearDb)
                    {
                        DbInitializer.ClearDb(context);
                    }

                    if (appConfig.SeedDb)
                    {
                        DbInitializer.InitializeDb(context);
                    }
                }
            }

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
