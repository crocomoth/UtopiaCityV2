using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Vacancy: ExtendedBusinessEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
    }
}
