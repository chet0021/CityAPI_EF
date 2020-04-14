using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Resources;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/mayors")]
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

		[HttpGet]
		public IActionResult GetMayors([FromQuery] MayorResources resourceParameter)
		{
			var mayors = _mayorInfoRepository.GetMayors(resourceParameter);

			return Ok(_mapper.Map<IEnumerable<MayorDTO>>(mayors));
		}

		[HttpGet("{id}")]
		public IActionResult GetMayor(int id)
		{
			var mayor = _mayorInfoRepository.GetMayor(id);

			if (mayor == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<MayorDTO>(mayor));
		}

		[HttpPost]
		public IActionResult CreateMayor([FromBody] MayorDetailsDTO mayorDTO)
		{
			try
			{
				if (mayorDTO.Age < 40)
				{
					ModelState.AddModelError("Age", "Mayor is Underage");
				}

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
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
		[HttpPut("{mayorId}")]
		public IActionResult UpdateMayor(int mayorId, [FromBody] MayorDetailsDTO mayorDTO)
		{
			try
			{
				if (mayorDTO.Age < 40)
				{
					ModelState.AddModelError("Age", "Mayor is Underage");
				}

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var entityMayor = _mayorInfoRepository.GetMayor(mayorId);
				if (entityMayor == null)
				{
					return NotFound();
				}
				_mapper.Map(mayorDTO, entityMayor);
				_mayorInfoRepository.UpdateMayor(mayorId, entityMayor);
				_mayorInfoRepository.Save();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{mayorId}")]
		public IActionResult DeleteMayor(int mayorId)
		{
			try
			{
				_mayorInfoRepository.DeleteMayor(mayorId);
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