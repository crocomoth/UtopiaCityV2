using System.Threading.Tasks;
using UtopiaCity.ViewModels.Business.Position;

namespace UtopiaCity.Services.Business
{
    public interface IPositionService
    {
        Task CreatePosition(CreatePositionViewModel createPositionViewModel);
        Task DeletePosition(string positionId);
    }
}
