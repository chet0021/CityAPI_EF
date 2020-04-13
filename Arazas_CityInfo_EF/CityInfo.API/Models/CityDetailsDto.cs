using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class CityDetailsDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
