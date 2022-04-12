using AutoMapper;
using DogNet.Immo.Core.Models;

namespace DogNet.Immo.Presentation.Site.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            this.CreateMap<User, Models.UserCreate>().ReverseMap();
            this.CreateMap<UserData, Models.UserData>().ReverseMap();
            this.CreateMap<User, Models.UserData>().ReverseMap();
        }
    }
}
