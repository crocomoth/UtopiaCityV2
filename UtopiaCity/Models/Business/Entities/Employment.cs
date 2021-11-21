using UtopiaCity.Models.Business.Temp;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Employment: ExtendedEntity
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
    }
}