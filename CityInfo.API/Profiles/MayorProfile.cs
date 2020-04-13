using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class MayorProfile : Profile
    {
        public MayorProfile()
        {
            CreateMap<Mayor, MayorDto>();
            CreateMap<MayorDetailsDto, Mayor>();
        }
    }
}
