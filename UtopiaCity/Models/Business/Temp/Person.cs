using System;
using UtopiaCity.Models.Business.Common;

namespace UtopiaCity.Models.Business.Temp
{
    public class Person: ExtendedBusinessEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}