using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Common.Initializers
{
    public class EmergencyReportIntializer : ISubDbInitializer
    {
        public void ClearSet(AppDbContext context)
        {
            if (!context.EmergencyReport.Any())
            {
                return;
            }

            context.RemoveRange(context.EmergencyReport.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(AppDbContext context)
        {
            if (context.EmergencyReport.Any())
            {
                return;
            }

            var report1 = new EmergencyReport
            {
                Id = "1",
                Data = "Report 1",
                ReportTime = DateTime.Now
            };

            var report2 = new EmergencyReport
            {
                Id = "2",
                Data = "Report 2",
                ReportTime = DateTime.Now
            };

            var report3 = new EmergencyReport
            {
                Id = "3",
                Data = "Report 3",
                ReportTime = DateTime.Now
            };

            context.AddRange(report1, report2, report3);
            context.SaveChanges();
        }
    }
}
