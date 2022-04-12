using AutoMapper;
using DogNet.Immo.Core.Models;

namespace DogNet.Immo.Data.Providers.Sql
{
    public class SqlMapping : Profile
    {
        public SqlMapping()
        {
            this.CreateMap<Models.Realty, Realty>().ReverseMap();
            this.CreateMap<Models.User, User>().ReverseMap();
        }
    }
}
