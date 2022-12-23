using AutoMapper;
using Dtos.VehicleDtos;
using Dtos.VehicleTypeDtos;
using Dtos.UserDtos;
using Entities;

namespace Mappers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Vehicle, ViewVehicleDto>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();

            CreateMap<VehicleType, ViewVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, CreateVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, UpdateVehicleTypeDto>().ReverseMap();

            CreateMap<User, ViewUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
