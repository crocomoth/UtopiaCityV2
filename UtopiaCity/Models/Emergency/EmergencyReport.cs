using System;

namespace UtopiaCity.Models.Emergency
{
    /// <summary>
    /// This is Emergency example class.
    /// </summary>
    public class EmergencyReport
    {
        public string Id { get; set; }
        /// <summary>
        /// This is some generic data.
        /// </summary>
        public string Data { get; set; }
        public DateTime ReportTime { get; set; }

        public EmergencyReport()
        {
        }

        public EmergencyReport(string id, string data, DateTime reportTime)
        {
            Id = id;
            Data = data;
            ReportTime = reportTime;
        }
    }
}
