using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDetailsDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string NickName { get; set; }
        [Range(30,100)]
        public int Age { get; set; }
    }
}
