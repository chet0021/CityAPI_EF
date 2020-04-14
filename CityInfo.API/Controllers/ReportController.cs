using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[Route("api/report")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly ICityInfoRepository _cityInfoRepository;
		private readonly IMapper _mapper;
		public ReportController(ICityInfoRepository cityInfoRepository,
			IMapper mapper)
		{
			_cityInfoRepository = cityInfoRepository ??
				throw new ArgumentNullException(nameof(cityInfoRepository));
			_mapper = mapper ??
				throw new ArgumentNullException(nameof(mapper));
		}
		[HttpGet("{cityId}")]
		public FileContentResult GetPointOfInterests(int cityId)
		{
			var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterestForCity(cityId);
			var poiModel = _mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity);

			var ms = new MemoryStream();
			using (var writer = new StreamWriter(ms))
			{
				using (var csv = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
				{					
					csv.WriteRecords(poiModel);
				}
			}
			var byteArray = ms.ToArray();
			ms.Flush();
			var contentType = "application/text";
			return File(byteArray, contentType, $"pointOfInterest - {cityId}.csv");
		}
	}
}