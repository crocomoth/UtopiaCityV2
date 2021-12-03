using System.Threading.Tasks;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Services.Business
{
    public interface ICompanyService
    {
        Task<ApplyCompanyViewModel> CreateApplyCompanyViewModel();
        Task ApplyCompany(ApplyCompanyViewModel applyCompanyViewModel);
        Task CreateCompany(Company company);
    }
}
