using Microsoft.AspNetCore.Mvc;
using System;
using UtopiaCity.Services.FireDepartment.FireIncidentReportServices;
using UtopiaCity.ViewModels.FireDepartment;

namespace UtopiaCity.Controllers.FireDepartment
{
    public class FireDepartmentController : Controller
    {
        private readonly IFireIncidentReportService _fireIncidentReportService;

        public FireDepartmentController(IFireIncidentReportService fireIncidentReportService)
        {
            _fireIncidentReportService = fireIncidentReportService;
        }

        public IActionResult Index()
        {
            var viewModel = _fireIncidentReportService.GetAllFireIncidentReportViewModels();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateFireIncidentReport()
        {
            CreateFireIncidentReportViewModel viewModel = new CreateFireIncidentReportViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateFireIncidentReport(CreateFireIncidentReportViewModel viewModel)
        {
            try
            {
                _fireIncidentReportService.CreateFireIncidentReport(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
