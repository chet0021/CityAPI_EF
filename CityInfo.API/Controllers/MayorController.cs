using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;

namespace CityInfo.API.Controllers
{
    [Route("api/Mayor")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        private readonly IMayorInfoRepository _mayorInfoRepository;
        private readonly IMapper _mapper;
        
        public MayorController(IMayorInfoRepository mayorInfoRepository, IMapper mapper)
        {
            _mayorInfoRepository = mayorInfoRepository ?? throw new ArgumentNullException(nameof(mayorInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
           
        }
        [HttpGet(Name = "GetMayors")]
        public IActionResult GetMayors()
        {
            var mayorEntities = _mayorInfoRepository.GetMayors();
            return Ok(_mapper.Map<IEnumerable<MayorDto>>(mayorEntities));
        }
        [HttpGet("{id}")]
        public IActionResult GetMayor(int id, bool includeCity = false)
        {
            var mayor = _mayorInfoRepository.GetMayor(id, includeCity);

            if (mayor == null)
            {
                return NotFound();
            }

            if (includeCity)
            {
                return Ok(_mapper.Map<MayorDto>(mayor));
            }

            return Ok(_mapper.Map<MayorDto>(mayor));
        }
        [HttpPost]
        public IActionResult CreateMayor([FromBody] MayorDto mayorDTO)
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
        public IActionResult UpdateMayor(int mayorID, [FromBody] MayorDto mayorDTO)
        {
            try
            {
                var entityMayor = _mayorInfoRepository.GetMayor(mayorID, false);
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