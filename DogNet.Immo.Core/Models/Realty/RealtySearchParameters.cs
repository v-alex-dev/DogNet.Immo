namespace DogNet.Immo.Core.Models
{
    public class RealtySearchParameters
    {
        public string City { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? AreaMin { get; set; }
        public bool? ForSale { get; set; }
    }
}
