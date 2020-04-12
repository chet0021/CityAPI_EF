using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class MayorProfile : Profile
    {
        public MayorProfile()
        {
            CreateMap<Entities.Mayor, Models.CityMayor>();
        }
    }
}
