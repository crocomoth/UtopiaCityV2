using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Business;
using UtopiaCity.ViewModels.Business.Vacancy;

namespace UtopiaCity.Controllers.Business
{
    public class VacancyController: BaseController
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> CreateVacancy(string companyId)
        {
            var createVacancyViewModel = await _vacancyService.CreateCreateVacancyViewModel(companyId);
            return View("Views/Business/Vacancy/CreateVacancy.cshtml", createVacancyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacancy(CreateVacancyViewModel createVacancyViewModel)
        {
            await _vacancyService.CreateVacancy(createVacancyViewModel);
            return RedirectToAction("Index", "Business");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVacancy(string vacancyId)
        {
            await _vacancyService.DeleteVacancy(vacancyId);
            return RedirectToAction("Index", "Business");
        }
    }
}
