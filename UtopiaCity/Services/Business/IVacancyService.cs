using System.Threading.Tasks;
using UtopiaCity.ViewModels.Business.Vacancy;

namespace UtopiaCity.Services.Business
{
    public interface IVacancyService
    {
        Task<CreateVacancyViewModel> CreateCreateVacancyViewModel(string companyId);
        Task CreateVacancy(CreateVacancyViewModel createVacancyViewModel);
        Task DeleteVacancy(string vacancyId);
    }
}