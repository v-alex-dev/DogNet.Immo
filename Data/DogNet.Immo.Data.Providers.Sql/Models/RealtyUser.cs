using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogNet.Immo.Data.Providers.Sql.Models
{
    [Table("RealtyUser")]
    public class RealtyUser
    {
        [Key]
        public int Id { get; set; }
        public int RealtyId { get; set; }
        public int UserId { get; set; }
    }
}
