using UtopiaCity.Models.Business.Common;
using UtopiaCity.Models.Business.Temp;

namespace UtopiaCity.Models.Business.Entities
{
    public class Employment: ExtendedBusinessEntity
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
    }
}