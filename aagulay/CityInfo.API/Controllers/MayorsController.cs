using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/mayors")]
    public class MayorsController : ControllerBase
    {
        private readonly IMayorRepository _mayorRepository;
        private readonly IMapper _mapper;

        public MayorsController(IMayorRepository mayorRepository, 
            IMapper mapper)
        {
            _mayorRepository = mayorRepository ??
                   throw new ArgumentNullException(
                       nameof(mayorRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(
                    nameof(mapper));
        }

        [HttpGet(Name = "GetMayors")]
        public IActionResult GetMayors() {
            var mayorEntities = _mayorRepository.GetMayors();
            return Ok(_mapper.Map<IEnumerable<MayorDTO>>(mayorEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetMayor(int id) {
            var mayor = _mayorRepository.GetMayor(id);
            if (mayor == null) {
                return NotFound();
            }
            return Ok(_mapper.Map<MayorDTO>(mayor));

        }

        [HttpPost]
        public IActionResult AddMayor([FromBody] MayorDetailsDTO mayorDTO) {
            try {
                var newMayor = _mapper.Map<Mayor>(mayorDTO);
                _mayorRepository.AddMayor(newMayor);
                _mayorRepository.Save();
                return Ok();
            }

            catch (Exception e) {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{mayorId}")]
        public IActionResult UpdateMayorInfo(int mayorId, [FromBody] MayorDetailsDTO mayorDTO) {
            try
            {
                var mayor = _mayorRepository.GetMayor(mayorId);
                if (mayor == null) {
                    return NotFound();
                }
                _mapper.Map(mayorDTO, mayor);
                _mayorRepository.UpdateMayorInfo(mayorId, mayor);
                _mayorRepository.Save();
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{mayorId}")]
        public IActionResult RemoveMayor(int mayorId) {
            try
            {
                _mayorRepository.RemoveMayor(mayorId);
                _mayorRepository.Save();
                return Ok();
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }






    }
}