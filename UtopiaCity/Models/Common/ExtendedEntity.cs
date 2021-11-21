using System;

namespace UtopiaCity.Models.Common
{
    public class ExtendedEntity: BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }
}