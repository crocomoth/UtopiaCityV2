using System;

namespace UtopiaCity.Models.Business.Common
{
    public class ExtendedBusinessEntity: BaseBusinessEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
    }
}