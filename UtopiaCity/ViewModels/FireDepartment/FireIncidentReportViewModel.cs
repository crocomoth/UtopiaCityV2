using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.ViewModels.FireDepartment
{
    public class FireIncidentReportViewModel
    {
        public string Id { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public string EyewitnessId { get; set; }
    }
}
