using System;
using UtopiaCity.Models.Common;

namespace UtopiaCity.Models.Business.Temp
{
    public class Person: ExtendedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}