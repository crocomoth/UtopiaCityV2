using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data.MapConfigurations;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.Models.Business.Temp;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.FireDepartment;

namespace UtopiaCity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<FireIncidentReport> FireIncidentReports { get; set; }

        #region Business

        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employment> Employments { get; set; }

        #endregion

        #region CityHall

        public DbSet<Person> Persons { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FireIncidentReportDbMap());
        }
    }
}
