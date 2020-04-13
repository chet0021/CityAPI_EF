using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using AutoMapper;
using System.Text.RegularExpressions;

namespace CityInfo.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MayorsController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public MayorsController(ICityInfoRepository cityInfoRepository,
             IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetMayors")]
		public IActionResult GetMayors([FromQuery] string gender, [FromQuery] string name)
		{
            
            if (gender != null&&name==null)
            {
               var gmayorEntities =  _cityInfoRepository.GetMayors().Where(m => m.Gender == gender);
                return Ok(_mapper.Map<IEnumerable<MayorDTO>>(gmayorEntities));
            }
            else if(gender==null&&name!=null)
            {
                var nospacename = Regex.Replace(name, @"\s+", "").ToLower();
                var nmayorEntities = _cityInfoRepository.GetMayors().Where(m => Regex.Replace(m.Name, @"\s+", "").ToLower().Contains(nospacename));
                return Ok(_mapper.Map<IEnumerable<MayorDTO>>(nmayorEntities));
            }
            else
            {
                var mayorEntities = _cityInfoRepository.GetMayors();
                return Ok(_mapper.Map<IEnumerable<MayorDTO>>(mayorEntities));
            }
		}

     

        [HttpGet("{id}")]
        public IActionResult GetMayor(int id)
        {
            var mayor = _cityInfoRepository.GetMayor(id);

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
                var entityMayor = _mapper.Map<Mayor>(mayorDTO);
                if (_cityInfoRepository.GetMayors().Any(m => m.Name == mayorDTO.Name)||mayorDTO.Age<40)
                 {
                    return BadRequest();
                }

                _cityInfoRepository.CreateMayor(entityMayor);
                _cityInfoRepository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{mayorId}")]
        public IActionResult DeleteMayor (int mayorId)
        {
            try
            {
                _cityInfoRepository.DeleteMayor(mayorId);
                _cityInfoRepository.Save();
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
                var entityMayor = _cityInfoRepository.GetMayor(mayorId);
                if (entityMayor == null)
                {
                    return NotFound();
                }
                _mapper.Map(mayorDTO, entityMayor);
                _cityInfoRepository.UpdateMayor(mayorId, entityMayor);
                _cityInfoRepository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



       
    }
}