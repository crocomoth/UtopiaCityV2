using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Extensions;
using UtopiaCity.Data;
using UtopiaCity.Models;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly EmergencyReportService _emergencyReportService;

        public EmergencyReportController(AppDbContext dbContext, EmergencyReportService emergencyReportService)
        {
            _dbContext = dbContext;
            _emergencyReportService = emergencyReportService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View("ListEmergencyReportView", await _dbContext.EmergencyReport.ToListAsync());
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

            return TryExecuteViewResult(() =>
            {
                _emergencyReportService.AddNewEmergencyReport(newReport);
                return RedirectToAction(nameof(Index));
            });
        }

        private ActionResult TryExecuteViewResult(Func<ActionResult> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception e)
            {
                return this.ViewError(e);
            }
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
                try
                {
                    _emergencyReportService.EditEmergencyReport(emergencyReport);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception e)
                {
                    return View(new ErrorViewModel() { Data = e.Message });
                }
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
            var report = _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
            if (report == null)
            {
                return NotFound();
            }

            _dbContext.Remove(report);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
