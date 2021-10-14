using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.FireService;

namespace UtopiaCity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<FireIncidentReport> FireIncidentReports { get; set; }
    }
}
