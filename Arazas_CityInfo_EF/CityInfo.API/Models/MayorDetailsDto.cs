using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class MayorDetailsDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}
