using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Entities
{
    public class Employment: ExtendedBusinessEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
    }
}
