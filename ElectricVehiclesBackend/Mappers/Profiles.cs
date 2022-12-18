using AutoMapper;
using CQRS.Commands.BikeCommands;
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

            CreateMap<Bike, CreateBikeCommand>().ReverseMap();
            CreateMap<Bike, UpdateBikeCommand>().ReverseMap();
            CreateMap<CreateBikeCommand, CreateBikeDto>().ReverseMap();
            CreateMap<CreateBikeDto, ViewBikeDto>().ReverseMap();
            CreateMap<UpdateBikeCommand, UpdateBikeDto>().ReverseMap();
            CreateMap<UpdateBikeDto, ViewBikeDto>().ReverseMap();
        }
    }
}
