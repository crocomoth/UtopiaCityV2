using System.Threading;

namespace UtopiaCity.Dtos.Common
{
    public class BaseRequestDto
    {
        public CancellationToken CancellationToken { get; set; }
    }
}