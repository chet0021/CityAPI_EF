using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class CityMayor
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        public char Gender { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(40, 100, ErrorMessage = "Underage being a mayor")]
        public int Age { get; set; }
    }
}
