using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityWithoutPointOfInterestsDto>();
            CreateMap<City, CityDto>();
            CreateMap<CityDetailsDto, City>();
        }
    }
}
