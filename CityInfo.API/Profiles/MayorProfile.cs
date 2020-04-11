using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Profiles
{
    public class MayorProfile : Profile
    {
        public MayorProfile()
        {
            CreateMap<Entities.Mayor, Models.MayorDto>();
            CreateMap<Entities.Mayor, Models.MayorDto>();
            CreateMap<Models.CityDto, Entities.Mayor>();
        }
    }
}
