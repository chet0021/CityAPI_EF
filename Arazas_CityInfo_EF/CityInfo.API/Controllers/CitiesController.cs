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
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCities")]
        public IActionResult GetCities()
        {
            var cities = _cityInfoRepository.GetCities();

            return Ok(_mapper.Map<IEnumerable<CityDto>>(cities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointOfInterests = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointOfInterests);
            
            if (city == null)
            {
                return NotFound();
            }

            if (includePointOfInterests)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityDto>(city));
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody] CityDetailsDto cityDto)
        {
            try
            {
                var newCity = _mapper.Map<City>(cityDto);
                _cityInfoRepository.CreateCity(newCity);
                _cityInfoRepository.Save();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cityId}")]
        public IActionResult UpdateCity(int cityId, [FromBody] CityDetailsDto cityDto)
        {
            try
            {
                var city = _cityInfoRepository.GetCity(cityId, false);

                if (city == null)
                {
                    return NotFound();
                }

                _mapper.Map(cityDto, city);
                _cityInfoRepository.UpdateCity(cityId, city);
                _cityInfoRepository.Save();
                return Ok();
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            try
            {
                _cityInfoRepository.DeleteCity(cityId);
                _cityInfoRepository.Save();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
