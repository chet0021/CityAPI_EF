using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
	public abstract class BaseCityDetailsDTO
	{
		[Required(ErrorMessage = "Please fill in Name")]
		[MaxLength(30, ErrorMessage = "Name should not exceed 30 characters")]
		public string Name { get; set; }

		[MaxLength(100, ErrorMessage = "Description should not exceed 100 characters")]
		public virtual string Description { get; set; }
	}
}
