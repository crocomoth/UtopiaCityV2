using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Business;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Controllers.Business
{
    public class CompanyController: BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companyListViewModel = await _companyService.GetCompanies();
            return View("Views/Business/Company/CompanyList.cshtml", companyListViewModel);
        }

        [HttpGet("[action]/{companyId}")]
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

        [HttpGet("[action]/{companyId}")]
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

        [HttpPost]
        public async Task<IActionResult> DeleteCompany(string companyId)
        {
            await _companyService.DeleteCompany(companyId);
            return RedirectToAction("Index", "Business");
        }
    }
}
