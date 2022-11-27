using AutoMapper;
using Domain.Entities;
using Domain.Models.BikeModels;
using Domain.Models.BikeTypeModels;
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

            CreateMap<BikeType, BikeTypeForView>().ReverseMap();
            CreateMap<BikeType, BikeTypeForCreation>().ReverseMap();
            CreateMap<BikeType, BikeTypeForUpdate>().ReverseMap();

            CreateMap<User, UserForView>().ReverseMap();
            CreateMap<User, UserForCreation>().ReverseMap();
            CreateMap<User, UserForUpdate>().ReverseMap();
        }
    }
}
