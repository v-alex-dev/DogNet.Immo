using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogNet.Immo.Data.Providers.Sql.Models
{
    [Table("Realty")]
    public class Realty
    {
        [Key]
        public int Id { get; set; }
        public int RealtyTypeId { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool ForSale { get; set; }
        public bool IsSold { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
