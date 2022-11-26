using AutoMapper;
using Domain.Entities;
using Domain.Models.BikeModels;

namespace API.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Bike, BikeForView>().ReverseMap();
            CreateMap<Bike, BikeForCreation>().ReverseMap();
            CreateMap<Bike, BikeForUpdate>().ReverseMap();
        }
    }
}
