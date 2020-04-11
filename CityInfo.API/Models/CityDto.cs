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
		public string Description { get; set; }
		public int NumberOfPointsOfInterest
		{
			get
			{
				return PointsOfInterest.Count;
			}
		}
		public string CityFullName
		{
			get
			{
				return $"{this.Name} - {this.Description}";
			}
		}
		public ICollection<PointOfInterestDto> PointsOfInterest { get; set; }
		  = new List<PointOfInterestDto>();

	}
}
