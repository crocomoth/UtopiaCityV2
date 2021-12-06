using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Common
{
    public class BaseObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}
