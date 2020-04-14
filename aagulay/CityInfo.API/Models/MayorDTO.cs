using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}
