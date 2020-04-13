using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MayorInfo.API.Models
{
	public class MayorDetailsDto
	{
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
		public int Age { get; set; }
		[MaxLength(1)]
		public int Gender { get; set; }
	}
}
