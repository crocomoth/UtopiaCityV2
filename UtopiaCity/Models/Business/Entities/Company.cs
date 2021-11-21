using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Company: ExtendedBusinessEntity
    {
        public string Title { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyActionId { get; set; }
    }
}