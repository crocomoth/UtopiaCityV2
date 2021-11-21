using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UtopiaCity.Models.Business.Temp;

namespace UtopiaCity.Services.Business.Application
{
    public interface IPictureService
    {
        Task<Picture> AddPicture(IFormFile file);
        Task DeletePicture(string pictureId, CancellationToken cancellationToken);
    }
}