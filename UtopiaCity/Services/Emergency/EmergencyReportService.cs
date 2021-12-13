using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Services.Emergency
{
    /// <summary>
    /// This is service to handle basic CRUD opereations for <see cref="EmergencyReport"/>
    /// </summary>
    public class EmergencyReportService
    {
        private readonly AppDbContext _dbContext;
        private readonly GenericDataProvider<EmergencyReport> _provider;

        public EmergencyReportService(AppDbContext context, GenericDataProvider<EmergencyReport> provider)
        {
            _dbContext = context;
            _provider = provider;
        }

        public virtual async Task<List<EmergencyReport>> GetAllReportsAsync()
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
            return _provider.Get(id).GetAwaiter().GetResult();
            //return _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddNewEmergencyReport(EmergencyReport newReport)
        {
            _provider.Add(newReport).GetAwaiter().GetResult();
            //_dbContext.Add(newReport);
            //int entries = _dbContext.SaveChanges();
            //if (entries == 0)
            //{
            //    throw new Exception($"{this} could not perform save for report.");
            //}
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
