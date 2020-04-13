using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using AutoMapper;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/mayors")]
    [ApiController]
    public class CityMayorController : ControllerBase
    {
        private readonly IMayorInfoRepository _mayorInfoRepository;
        private readonly IMapper _mapper;

        public CityMayorController(IMayorInfoRepository mayorInfoRepository,
            IMapper mapper)
        {
            _mayorInfoRepository = mayorInfoRepository ??
                throw new ArgumentNullException(nameof(mayorInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        //api/cities/mayors
        [HttpGet(Name = "GetMayors")]
        public IActionResult GetMayors()
        {

            var mayors = _mayorInfoRepository.GetCityMayors();
            return Ok(_mapper.Map<IEnumerable<CityMayor>>(mayors));
        }

        //api/cities/mayors
        [HttpPost]
        public IActionResult AddMayors([FromBody] Mayor mayor)
        {
            try
            {
                var mayors = _mapper.Map<Mayor>(mayor);
                _mayorInfoRepository.CreateMayor(mayors);
                _mayorInfoRepository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        ///breakpoint
        //api/cities/mayors/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMayor(int id, Mayor mayor)
        {
            try
            {
                var entityMayor = _mayorInfoRepository.GetCtMayors(id);
                if (entityMayor == null)
                {
                    return NotFound();
                }

                _mapper.Map(mayor, entityMayor);
                _mayorInfoRepository.UpdateMayor(id, entityMayor);
                _mayorInfoRepository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //api/cities/mayors/{mayorName}
        [HttpDelete("{id}")]
        public IActionResult DeleteMayor(int id)
        {
            try
            {
                _mayorInfoRepository.DeleteMayor(id);
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