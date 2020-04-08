using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayorController : ControllerBase
    {
		private readonly IMayorInfoRepository _mayorInfoRepository;
		private readonly IMapper _mapper;

		public MayorController(IMayorInfoRepository mayorInfoRepository,
			IMapper mapper)
		{
			_mayorInfoRepository = mayorInfoRepository ??
				throw new ArgumentNullException(nameof(mayorInfoRepository));
			_mapper = mapper ??
				throw new ArgumentNullException(nameof(mapper));
		}

		[HttpGet(Name = "GetMayors")]
		public IActionResult GetMayors()
		{
			var mayorEntities = _mayorInfoRepository.GetMayors();

			//var results = new List<CityWithoutPointsOfInterestDto>();

			//foreach (var mayorEntity in mayorEntities)
			//{
			//    results.Add(new CityWithoutPointsOfInterestDto
			//    {
			//        Id = mayorEntity.Id,
			//        Description = mayorEntity.Description,
			//        Name = mayorEntity.Name
			//    });
			//}

			return Ok(_mapper.Map<IEnumerable<MayorDTO>>(mayorEntities));
		}

		[HttpGet("{id}")]
		public IActionResult GetCity(int id)
		{
			var mayor = _mayorInfoRepository.GetMayor(id);

			if (mayor == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<MayorDTO>(mayor));
		}

		[HttpPost]
		public IActionResult CreateMayor([FromBody] MayorDTO mayorDTO)
		{
			try
			{
				var entityMayor = _mapper.Map<Mayor>(mayorDTO);
				_mayorInfoRepository.CreateMayor(entityMayor);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpPut("{mayorID}")]
		public IActionResult UpdateMayor(int mayorID, [FromBody] MayorDTO mayorDTO)
		{
			try
			{
				var entityMayor = _mayorInfoRepository.GetMayor(mayorID);
				if (entityMayor == null)
				{
					return NotFound();
				}
				_mapper.Map(mayorDTO, entityMayor);
				_mayorInfoRepository.UpdateMayor(mayorID, entityMayor);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{mayorID}")]
		public IActionResult DeleteMayor(int mayorID)
		{
			try
			{
				_mayorInfoRepository.DeleteMayor(mayorID);
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
