using AutoMapper;
using Dtos;
using Models;

namespace Mappers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Bike, BikeDto>().ReverseMap();
        }
    }
}
