using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
	public class CityDetailsDTOUpdate : BaseCityDetailsDTO
	{
		[Required]		
		public override string Description { get => base.Description; set => base.Description = value; }
	}
}
