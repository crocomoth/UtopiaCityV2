using System;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Common.Attributes;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.Emergency
{
    /// <summary>
    /// This is Emergency example class.
    /// </summary>
    public class EmergencyReport : BaseObject
    {
        /// <summary>
        /// This is some generic data.
        /// </summary>
        [Lowercase(ErrorMessage = "data is not lowercase")]
        public string Data { get; set; }
        [DateTimeRange("01/01/2019")]
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
