using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Position: ExtendedBusinessEntity
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public string Title { get; set; }
    }
}