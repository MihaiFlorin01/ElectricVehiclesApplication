using AutoMapper;
using Domain.Entities;
using Domain.Models.BikeModels;
using Domain.Models.UserModels;

namespace API.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Bike, BikeForView>().ReverseMap();
            CreateMap<Bike, BikeForCreation>().ReverseMap();
            CreateMap<Bike, BikeForUpdate>().ReverseMap();

            CreateMap<User, UserForView>().ReverseMap();
            CreateMap<User, UserForCreation>().ReverseMap();
            CreateMap<User, UserForUpdate>().ReverseMap();
        }
    }
}
