using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UtopiaCity.Common;
using UtopiaCity.Data;
using UtopiaCity.Extensions;
using UtopiaCity.Services.Emergency;

namespace UtopiaCity
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            #region Services

            services.AddScoped<EmergencyReportService, EmergencyReportService>();

            #endregion

            services.Configure<AppConfig>(_configuration.GetSection(AppConfig.Name));
            services.AddControllersWithViews();
            services.AddApiLayer();
            services.AddApplicationLayer();
            services.AddInfrastructureLayer(_configuration);
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var appConfig = _configuration.GetSection(AppConfig.Name).Get<AppConfig>();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
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
