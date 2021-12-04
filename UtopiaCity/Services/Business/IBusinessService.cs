using System.Threading.Tasks;
using UtopiaCity.ViewModels.Business;

namespace UtopiaCity.Services.Business
{
    public interface IBusinessService
    {
        Task<IndexViewModel> CreateIndexViewModel();
    }
}
