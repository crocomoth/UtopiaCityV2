using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Services.Emergency
{
    /// <summary>
    /// Service to access and perform operations with <see cref="EmergencyReport"/>
    /// </summary>
    public class EmergencyReportService
    {
        private readonly AppDbContext _appDbContext;

        public EmergencyReportService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public EmergencyReport GetEmergencyReport(string id)
        {
            return _appDbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddNewEmergencyReport(EmergencyReport newReport)
        {
            _appDbContext.Add(newReport);
            int entries = _appDbContext.SaveChanges();
            if (entries == 0)
            {
                throw new Exception($"{this} could not perform save for request");
            }
        }

        public void EditEmergencyReport(EmergencyReport emergencyReport)
        {
            _appDbContext.Update(emergencyReport);
            int entries = _appDbContext.SaveChanges();
            if (entries == 0)
            {
                throw new Exception($"{this} could not perform edit for request");
            }
        }
    }
}
