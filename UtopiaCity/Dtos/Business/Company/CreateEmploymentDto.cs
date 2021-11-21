using UtopiaCity.Dtos.Common;

namespace UtopiaCity.Dtos.Business.Company
{
    public class CreateEmploymentDto: BaseRequestDto
    {
        public string PersonId { get; set; }
        public string PositionId { get; set; }
    }
}