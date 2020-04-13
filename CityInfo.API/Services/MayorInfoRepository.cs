using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.API.Services
{
    public class MayorRepository : IMayorRepository
    {
        private readonly CityInfoContext _context;

        public MayorRepository(CityInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<Mayor> GetMayors()
        {
            return _context.Mayors
                .Include(m => m.City)
                .OrderByDescending(m => m.Name)
                .ToList();
        }

        public Mayor GetMayor(int mayorId)
        {
            return _context.Mayors
                .Include(m => m.City)
                .Where(m => m.Id == mayorId)
                .FirstOrDefault();
        }

        public bool IsMayorExists(int mayorId)
        {
            return _context.Mayors.Any(m => m.Id == mayorId);
        }

        public void AddMayor(Mayor mayor)
        {
            _context.Mayors.Add(mayor);
        }

        public void UpdateMayor(int mayorId, Mayor updateMayor)
        {
            var mayor = _context.Mayors.Where(m => m.Id == mayorId).FirstOrDefault();
        }

        public void DeleteMayor(int mayorId)
        {
            var mayor = _context.Mayors.Where(m => m.Id == mayorId).FirstOrDefault();

            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
