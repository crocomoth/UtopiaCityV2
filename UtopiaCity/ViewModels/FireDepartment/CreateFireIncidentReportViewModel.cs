using System;
using System.ComponentModel.DataAnnotations;


namespace UtopiaCity.ViewModels.FireDepartment
{
    public class CreateFireIncidentReportViewModel
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public string AdditionalInfo { get; set; }
        public string EyewitnessId { get; set; }
    }
}
