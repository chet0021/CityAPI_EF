using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDto
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		[ForeignKey("CityId")]
		public CityDto City { get; set; }
		public int CityId { get; set; }
		public ICollection<CityDto> Mayor { get; set; }
		  = new List<CityDto>();

	}
}

