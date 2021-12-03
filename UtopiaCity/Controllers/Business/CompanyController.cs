using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Business;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Controllers.Business
{
    [Route("business/[controller]/[action]")]
    public class CompanyController: BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> ApplyCompany()
        {
            var applyCompanyViewModel = await _companyService.CreateApplyCompanyViewModel(); 
            return View("Views/Business/Company/ApplyCompany.cshtml", applyCompanyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCompany(ApplyCompanyViewModel applyCompanyViewModel)
        {
            await _companyService.ApplyCompany(applyCompanyViewModel);
            return RedirectToAction("Index", "Business");
        }
    }
}
