using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EmergencyReportController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

            var report = _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
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
            if (ModelState.IsValid)
            {
                _dbContext.Add(newReport);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("CreateEmergencyReportView");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
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
                _dbContext.Update(emergencyReport);
                _dbContext.SaveChanges();
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

            var report = _dbContext.EmergencyReport.FirstOrDefault(x => x.Id.Equals(id));
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
