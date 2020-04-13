using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MayorInfo.API.Contexts;
using MayorInfo.API.Models;

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
        public IEnumerable<MayorDto> GetMayorDto(int mayorid, string gender, string searchText)
        {
            
            if (string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(searchText))
            {
                return _context.MayorDto;
            }
            var collection = _context.Mayor.Where(m => m.Id == mayorid) as IQueryable<MayorDto>;
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

            var mayorDto = await _context.MayorDto.FindAsync(id);

            if (mayorDto == null)
            {
                return NotFound();
            }

            return Ok(mayorDto);
        }

        // PUT: api/Mayors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMayorDto([FromRoute] int id, [FromBody] MayorDto mayorDto)
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
        public async Task<IActionResult> PostMayorDto([FromBody] MayorDto mayorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MayorDto.Add(mayorDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMayorDto", new { id = mayorDto.Id }, mayorDto);
        }

        // DELETE: api/Mayors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMayorDto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mayorDto = await _context.MayorDto.FindAsync(id);
            if (mayorDto == null)
            {
                return NotFound();
            }

            _context.MayorDto.Remove(mayorDto);
            await _context.SaveChangesAsync();

            return Ok(mayorDto);
        }

        private bool MayorDtoExists(int id)
        {
            return _context.MayorDto.Any(e => e.Id == id);
        }
    }
}