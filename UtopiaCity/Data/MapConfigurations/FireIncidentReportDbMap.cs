using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UtopiaCity.Models.FireDepartment;

namespace UtopiaCity.Data.MapConfigurations
{
    public class FireIncidentReportDbMap : IEntityTypeConfiguration<FireIncidentReport>
    {
        public void Configure(EntityTypeBuilder<FireIncidentReport> builder)
        {
            builder.HasKey(fir => fir.Id);
            builder.Property(fir => fir.Id).ValueGeneratedOnAdd().HasMaxLength(36);
            builder.Property(fir => fir.Address).HasMaxLength(128);
            builder.Property(fir => fir.EyewitnessId).HasMaxLength(36);
            builder.Property(fir => fir.AdditionalInfo).HasMaxLength(256);
        }
    }
}
