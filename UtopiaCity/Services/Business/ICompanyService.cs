using System.Threading.Tasks;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Services.Business
{
    public interface ICompanyService
    {
        Task<CompanyListViewModel> GetCompanies();
        Task<CompanyInfoViewModel> GetCompanyInfo(string companyId);
        Task<ApplyCompanyViewModel> CreateApplyCompanyViewModel();
        Task ApplyCompany(ApplyCompanyViewModel applyCompanyViewModel);
        Task CreateCompany(Company company);
        Task<UpdateCompanyViewModel> CreateUpdateCompanyViewModel(string companyId);
        Task UpdateCompany(UpdateCompanyViewModel updateCompanyViewModel);
        Task DeleteCompany(string companyId);
    }
}
