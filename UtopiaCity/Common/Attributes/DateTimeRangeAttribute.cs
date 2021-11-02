using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Common.Attributes
{
    public class DateTimeRangeAttribute : ValidationAttribute
    {
        private readonly string min;
        private readonly string max;

        public DateTimeRangeAttribute(string min, string max)
        {
            this.min = min;
            this.max = max;
        }

        public DateTimeRangeAttribute(string min) : this(min, DateTime.Now.AddDays(1).ToString())
        {
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                var minDate = DateTime.Parse(min);
                var maxDate = DateTime.Parse(max);

                return date >= minDate && date <= maxDate;
            }

            return false;
        }
    }
}
