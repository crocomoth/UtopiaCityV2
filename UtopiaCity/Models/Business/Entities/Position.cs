using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Position: ExtendedBusinessEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
