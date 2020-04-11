using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    public class MayorsController : ControllerBase
    {
		private readonly IMayorInfoRepository _mayorInfoRepository;
		private readonly IMapper _mapper;

		public MayorsController(IMayorInfoRepository mayorInfoRepository,
			IMapper mapper)
		{
			_mayorInfoRepository = mayorInfoRepository ??
				throw new ArgumentNullException(nameof(mayorInfoRepository));
			_mapper = mapper ??
				throw new ArgumentNullException(nameof(mapper));
		}

		[HttpGet(Name = "GetMayors")]
		public IActionResult GetCities()
		{
			var cityEntities = _mayorInfoRepository.GetCities();

			//var results = new List<CityWithoutPointsOfInterestDto>();

			//foreach (var cityEntity in cityEntities)
			//{
			//    results.Add(new CityWithoutPointsOfInterestDto
			//    {
			//        Id = cityEntity.Id,
			//        Description = cityEntity.Description,
			//        Name = cityEntity.Name
			//    });
			//}

			return Ok(_mapper.Map<IEnumerable<MayorDTO>>(cityEntities));
		}

		[HttpGet("{id}")]
		public IActionResult GetCity(int id, bool includePointsOfInterest = false)
		{
			var city = _mayorInfoRepository.GetCity(id, includePointsOfInterest);

			if (city == null)
			{
				return NotFound();
			}

			if (includePointsOfInterest)
			{
				return Ok(_mapper.Map<MayorDTO>(city));
			}

			return Ok(_mapper.Map<MayorDTO>(city));
		}

		[HttpPost]
		public IActionResult CreateCity([FromBody] CityDetailsDto cityDTO)
		{
			try
			{
				var entityMayor = _mapper.Map<Mayor>(cityDTO);
				_mayorInfoRepository.CreateCity(entityMayor);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpPut("{mayorID}")]
		public IActionResult UpdateCity(int mayorID, [FromBody] CityDetailsDto cityDTO)
		{
			try
			{
				var entityCity = _mayorInfoRepository.GetCity(mayorID, false);
				if (entityCity == null)
				{
					return NotFound();
				}
				_mapper.Map(cityDTO, entityCity);
				_mayorInfoRepository.UpdateCity(mayorID, entityCity);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{mayorID}")]
		public IActionResult DeleteCity(int mayorID)
		{
			try
			{
				_mayorInfoRepository.DeleteCity(mayorID);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

	}
}
