using UtopiaCity.Models.Common;
using UtopiaCity.Primitives.CityHall;

namespace UtopiaCity.Models.CityHall
{
    public class Application: ExtendedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationType ApplicationType { get; set; }
    }
}