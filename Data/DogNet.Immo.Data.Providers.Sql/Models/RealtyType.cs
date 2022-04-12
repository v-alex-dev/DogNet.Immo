using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogNet.Immo.Data.Providers.Sql.Models
{
    [Table("RealtyType")]
    public class RealtyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
