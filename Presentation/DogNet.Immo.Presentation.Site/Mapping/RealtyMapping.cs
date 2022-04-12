using AutoMapper;
using DogNet.Immo.Core.Models;

namespace DogNet.Immo.Presentation.Site.Mapping
{
    public class RealtyMapping : Profile
    {
        public RealtyMapping()
        {
            this.CreateMap<Models.Realty, Realty>().ReverseMap();
        }
    }
}
