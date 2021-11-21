using System.Threading.Tasks;
using UtopiaCity.Dtos.Business.Company;

namespace UtopiaCity.Services.Business.Application
{
    public interface ICompanyService
    {
        Task ApplyCompany(ApplyCompanyDto applyCompanyDto);
        Task CreateCompany(CreateCompanyDto createCompanyDto);
    }
}