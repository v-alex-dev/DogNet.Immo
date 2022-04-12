using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogNet.Immo.Data.Providers.Sql.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
