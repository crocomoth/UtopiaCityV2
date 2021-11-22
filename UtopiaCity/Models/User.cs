using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
