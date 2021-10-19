using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Services.Emergency
{
    /// <summary>
    /// This is service to handle basic CRUD opereations for <see cref="EmergencyReport"/>
    /// </summary>
    public class EmergencyReportService
    {
        private readonly AppDbContext _dbContext;

        public EmergencyReportService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<EmergencyReport>> GetAllReportsAsync()
        {
            return await _dbContext.EmergencyReport.ToListAsync();
        }

        /// <summary>
        /// This is a summary
        /// </summary>
        /// <param name="id">Id of report.</param>
        /// <returns>Report with specified Id.</returns>
        public EmergencyReport GetEmergencyReport(string id)
        {
            return _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddNewEmergencyReport(EmergencyReport newReport)
        {
            _dbContext.Add(newReport);
            int entries = _dbContext.SaveChanges();
            if (entries == 0)
            {
                throw new Exception($"{this} could not perform save for report.");
            }
        }

        public void UpdateEmergencyReport(EmergencyReport report)
        {
            _dbContext.Update(report);
            _dbContext.SaveChanges();
        }

        public void RemoveEmergencyReport(EmergencyReport report)
        {
            _dbContext.Remove(report);
            _dbContext.SaveChanges();
        }
    }
}
