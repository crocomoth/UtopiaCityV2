using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Business.Common
{
    public class BaseBusinessEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}
