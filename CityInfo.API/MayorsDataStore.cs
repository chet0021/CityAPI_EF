using MayorInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MayorInfo.API
{
    public class MayorsDataStore
    {
        public static MayorsDataStore Current { get; } = new MayorsDataStore();

        public List<MayorDto> Cities { get; set; }

        public MayorsDataStore()
        {
            // init dummy data
            Cities = new List<MayorDto>()
            {
                new MayorDto()
                {
                     Id = 1,
                     Name = "Mar Serrano",
                     Age = 41
                     
                },
                new MayorDto()
                {
                    Id = 2,
                    Name = "Bren Loria",
                    Age = 42
                    
                },
                
            };
        }

    }

}
