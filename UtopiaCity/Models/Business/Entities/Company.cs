using UtopiaCity.Models.Business.Common;
using UtopiaCity.Models.Business.Dictionaries;

namespace UtopiaCity.Models.Business.Entities
{
    public class Company: ExtendedBusinessEntity
    {
        public string Title { get; set; }
        public string FounderId { get; set; }
        public User Founder { get; set; }
        public string CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
        public string CompanyActivityId { get; set; }
        public CompanyActivity CompanyActivity { get; set; }
    }
}
