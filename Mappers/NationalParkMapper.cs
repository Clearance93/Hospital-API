using AutoMapper;
using ParkyApplication.Models;
using ParkyApplication.Models.Dtos;

namespace ParkyApplication.Mappers
{
    public class NationalParkMapper : Profile
    {
        public NationalParkMapper()
        {
            CreateMap<NationalParkModel, NationalParkDtos>().ReverseMap();
            CreateMap<TrailModels, TrailDto>().ReverseMap();
            CreateMap<TrailModels, CreateTrailDto>().ReverseMap();
            CreateMap<TrailModels, UpdatetrailDto>().ReverseMap();
        }
    }
}
