using System.Threading.Tasks;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Services.Business
{
    public interface IBusinessService
    {
        Task<IndexViewModel> CreateIndexViewModel();
    }
}
