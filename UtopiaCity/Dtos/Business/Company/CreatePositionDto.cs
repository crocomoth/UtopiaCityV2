using UtopiaCity.Dtos.Common;

namespace UtopiaCity.Dtos.Business.Company
{
    public class CreatePositionDto: BaseRequestDto
    {
        public string CompanyId { get; set; }
        public string Title { get; set; }
    }
}