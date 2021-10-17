using System;

namespace UtopiaCity.Models.FireDepartment
{
    public class FireIncidentReport
    {
        public string Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public string EyewitnessId { get; set; }
    }
}
