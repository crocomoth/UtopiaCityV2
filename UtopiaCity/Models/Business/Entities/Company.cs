using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Company: ExtendedEntity
    {
        public string Title { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyActionId { get; set; }
    }
}