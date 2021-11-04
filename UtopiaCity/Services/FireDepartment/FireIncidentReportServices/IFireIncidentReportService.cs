using System.Collections.Generic;
using UtopiaCity.ViewModels.FireDepartment;

namespace UtopiaCity.Services.FireDepartment.FireIncidentReportServices
{
    public interface IFireIncidentReportService
    {
        public void CreateFireIncidentReport(CreateFireIncidentReportViewModel viewModel);
        public List<FireIncidentReportViewModel> GetAllFireIncidentReportViewModels();
    }
}
