using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data.MapConfigurations;
using UtopiaCity.Models;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.FireDepartment;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.Models.Business.Dictionaries;

namespace UtopiaCity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<FireIncidentReport> FireIncidentReports { get; set; }
        public DbSet<User> User { get; set; }

        #region Business

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyActivity> CompanyActivities{ get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FireIncidentReportDbMap());
        }
    }
}
