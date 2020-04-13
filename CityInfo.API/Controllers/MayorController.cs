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
    [ApiController]
    [Route("api/mayors")]
    public class MayorsController : ControllerBase
    {
        private readonly IMayorRepository _mayorRepository;
        private readonly IMapper _mapper;

        public MayorsController(IMayorRepository mayorRepository, IMapper mapper)
        {
            _mayorRepository = mayorRepository ?? throw new ArgumentNullException(nameof(mayorRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetMayors()
        {
            var mayors = _mayorRepository.GetMayors();

            return Ok(_mapper.Map<IEnumerable<MayorDto>>(mayors));
        }

        [HttpGet("{id}")]
        public IActionResult GetMayor(int id)
        {
            var mayor = _mayorRepository.GetMayor(id);

            return Ok(_mapper.Map<MayorDto>(mayor));
        }

        [HttpPost]
        public IActionResult CreateMayor([FromBody] MayorDetailsDto mayorDto)
        {
            try
            {
                var entityMayor = _mapper.Map<Mayor>(mayorDto);
                _mayorRepository.AddMayor(entityMayor);
                _mayorRepository.Save();

                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{mayorId}")]
        public IActionResult UpdateMayor([FromBody] MayorDetailsDto mayorDto, int mayorId)
        {
            try
            {
                var entityMayor = _mayorRepository.GetMayor(mayorId);

                if (entityMayor == null) return NotFound();

                _mapper.Map(mayorDto, entityMayor);
                _mayorRepository.UpdateMayor(mayorId, entityMayor);
                _mayorRepository.Save();

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
                _mayorRepository.DeleteMayor(mayorId);
                _mayorRepository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}