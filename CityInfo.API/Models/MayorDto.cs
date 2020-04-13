using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MayorInfo.API.Models
{
	public class MayorDto
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
		public int Age { get; set; }
		[MaxLength(1)]
		public string Gender { get; set; }
		public string MayorFullName
		{
			get
			{
				return $"{this.Name} - {this.Age}";
			}
		}
		

	}
}
