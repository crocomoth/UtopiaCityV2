using UtopiaCity.Dtos.Common;

namespace UtopiaCity.Dtos.Business.Company
{
    public class CreateCompanyDto: BaseRequestDto
    {
        public string CompanyTitle { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyActionId { get; set; }
    }
}