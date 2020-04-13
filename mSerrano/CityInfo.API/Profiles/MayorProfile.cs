using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MayorInfo.API.Profiles
{
    public class MayorProfile : Profile
    {
        public MayorProfile()
        {
            CreateMap<Entities.Mayor, Models.MayorDto>();
            CreateMap<Models.MayorDetailsDto, Entities.Mayor>();
        }
    }
}
