using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Common
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}