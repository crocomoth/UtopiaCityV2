using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Position: ExtendedEntity
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public string Title { get; set; }
    }
}