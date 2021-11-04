using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UtopiaCity.Common.Attributes
{
    public class LowercaseAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string stringValue)
            {
                return stringValue.All(c => char.IsLower(c));
            }

            return false;
        }
    }
}
