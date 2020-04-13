using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayorsController : ControllerBase
    {
        private readonly MayorInfoContext _context;

        public MayorsController(MayorInfoContext context)
        {
            _context = context;
        }

        // GET: api/Mayors
        [HttpGet]
        public IEnumerable<Mayor> GetMayorDto(int mayorid, string gender, string searchText)
        {

            if (string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(searchText))
            {
                return _context.MayorDTO;
            }
            var collection = _context.MayorDTO.Where(m => m.Id == mayorid) as IQueryable<Mayor>;
            if (!string.IsNullOrEmpty(gender))
            {
                collection = collection.Where(m => m.Gender.Equals(gender));
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                collection = collection.Where(m => m.Name.Contains(searchText));
            }
            return collection;
        }

        // GET: api/Mayors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMayorDto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mayorDto = await _context.MayorDTO.FindAsync(id);

            if (mayorDto == null)
            {
                return NotFound();
            }

            return Ok(mayorDto);
        }

        // PUT: api/Mayors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMayorDto([FromRoute] int id, [FromBody] MayorDTO mayorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mayorDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(mayorDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MayorDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mayors
        [HttpPost]
        public async Task<IActionResult> PostMayorDto([FromBody] Mayor mayor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MayorDTO.Add(mayor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMayorDto", new { id = mayor.Id }, mayor);
        }

        // DELETE: api/Mayors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMayorDto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mayorDto = await _context.MayorDTO.FindAsync(id);
            if (mayorDto == null)
            {
                return NotFound();
            }

            _context.MayorDTO.Remove(mayorDto);
            await _context.SaveChangesAsync();

            return Ok(mayorDto);
        }

        private bool MayorDtoExists(int id)
        {
            return _context.MayorDTO.Any(e => e.Id == id);
        }
    }
}