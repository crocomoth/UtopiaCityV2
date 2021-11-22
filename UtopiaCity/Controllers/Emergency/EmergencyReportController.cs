using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using UtopiaCity.Common;
using UtopiaCity.Filters;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;

namespace UtopiaCity.Controllers.Emergency
{
    [Authorize]
    [CookieFilter]
    public class EmergencyReportController : BaseController
    {
        public const string ContollerName = "EmergencyReport";

        private readonly EmergencyReportService _emergencyReportService;
        private readonly AppConfig _appConfig;

        public EmergencyReportController(EmergencyReportService emergencyReportService, IOptions<AppConfig> options)
        {
            _emergencyReportService = emergencyReportService;
            _appConfig = options.Value;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View("ListEmergencyReportView", await _emergencyReportService.GetAllReportsAsync());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = _emergencyReportService.GetEmergencyReport(id);
            if (report == null)
            {
                NotFound();
            }

            return View("DetailsEmergencyReportView", report);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateEmergencyReportView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmergencyReport newReport)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateEmergencyReportView");
            }

            return TryExecuteActionResult(() =>
            {
                _emergencyReportService.AddNewEmergencyReport(newReport);
                return RedirectToAction(nameof(Index));
            });
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = _emergencyReportService.GetEmergencyReport(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("EditEmergencyReportView", report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, EmergencyReport emergencyReport)
        {
            if (id != emergencyReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _emergencyReportService.UpdateEmergencyReport(emergencyReport);
                return RedirectToAction(nameof(Index));
            }

            return View("EditEmergencyReportView", emergencyReport);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = _emergencyReportService.GetEmergencyReport(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("DeleteEmergencyReportView", report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var report = _emergencyReportService.GetEmergencyReport(id);
            if (report == null)
            {
                return NotFound();
            }

            _emergencyReportService.RemoveEmergencyReport(report);
            return RedirectToAction(nameof(Index));
        }
    }
}
