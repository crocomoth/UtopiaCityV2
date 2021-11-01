using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.FireDepartment;
using UtopiaCity.ViewModels.FireDepartment;

namespace UtopiaCity.Services.FireDepartment.FireIncidentReportServices
{
    public class FireIncidentReportService : IFireIncidentReportService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FireIncidentReportService(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateFireIncidentReport(CreateFireIncidentReportViewModel viewModel)
        {
            var fireIncidentReport = _mapper.Map<FireIncidentReport>(viewModel);
            _context.Add(fireIncidentReport);
            _context.SaveChanges();
        }

        public List<FireIncidentReportViewModel> GetAllFireIncidentReportViewModels()
        {
            var reports = _context.FireIncidentReports.ToList();
            var viewModels = _mapper.Map<List<FireIncidentReportViewModel>>(reports);
            return viewModels;
        }
    }
}
