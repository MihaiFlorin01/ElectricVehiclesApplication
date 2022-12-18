using AutoMapper;
using Dtos.BikeDtos;
using Dtos.BikeTypeDtos;
using Dtos.UserDtos;
using Entities;

namespace Mappers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Bike, ViewBikeDto>().ReverseMap();
            CreateMap<Bike, CreateBikeDto>().ReverseMap();
            CreateMap<Bike, UpdateBikeDto>().ReverseMap();

            CreateMap<BikeType, ViewBikeTypeDto>().ReverseMap();
            CreateMap<BikeType, CreateBikeTypeDto>().ReverseMap();
            CreateMap<BikeType, UpdateBikeTypeDto>().ReverseMap();

            CreateMap<User, ViewUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
