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

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanyInfo(string companyId)
        {
            var companyInfoViewModel = await _companyService.GetCompanyInfo(companyId);
            return View("Views/Business/Company/CompanyInfo.cshtml", companyInfoViewModel);
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

        [HttpGet("{companyId}")]
        public async Task<IActionResult> UpdateCompany(string companyId)
        {
            var updateCompanyViewModel = await _companyService.CreateUpdateCompanyViewModel(companyId);
            return View("Views/Business/Company/UpdateCompany.cshtml", updateCompanyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyViewModel updateCompanyViewModel)
        {
            await _companyService.UpdateCompany(updateCompanyViewModel);
            return RedirectToAction("Index", "Business");
        }
    }
}
