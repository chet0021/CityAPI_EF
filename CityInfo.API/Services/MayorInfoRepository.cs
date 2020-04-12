using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class MayorInfoRepository : IMayorInfoRepository
    {
        private readonly CityInfoContext _context;

        public MayorInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Mayor> GetCityMayors()
        {
            return _context.Mayor.OrderBy(c => c.Name).ToList();
        }

        public Mayor GetCtMayors(int Id)
        {
            return _context.Mayor.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool MayorExists(int mayorId)
        {
            return _context.Mayor.Any(c => c.Id == mayorId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateMayor(Mayor mayor)
        {
            _context.Mayor.Add(mayor);
        }

        public void UpdateMayor(int mayorId, Mayor mayor)
        {

        }

        public void DeleteMayor(int mayorId)
        {
            var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
            _context.Mayor.Remove(entity);
        }
    }
}
