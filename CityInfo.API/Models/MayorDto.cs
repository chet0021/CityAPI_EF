using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string MayorFullDetail
        {
            get
            {
                return $"{ Name } - { Age }";
            }
        }

        public CityDto City { get; set; }
    }
}
