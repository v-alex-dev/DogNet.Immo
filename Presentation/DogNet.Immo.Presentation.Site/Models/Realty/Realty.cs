using System;

namespace DogNet.Immo.Presentation.Site.Models
{
    public class Realty
    {
        public int Id { get; set; }
        public RealtyType RealtyTypeId { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool ForSale { get; set; }
        public bool IsSold { get; set; }
        public DateTime CreationDate { get; set; }
    }
}