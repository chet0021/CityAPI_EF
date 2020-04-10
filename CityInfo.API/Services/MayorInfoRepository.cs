using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class MayorInfoRepository : IMayorInfoRepository
    {
        private readonly CityInfoContext _context;
        public MayorInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Mayor> GetMayors()
        {
            return _context.Mayor.OrderBy(c => c.Name).ToList();
        }
        public Mayor GetMayor(int mayorId)
        {

            return _context.Mayor
                    .Where(c => c.Id == mayorId).FirstOrDefault();
        }
        public void CreateMayor(Mayor mayor)
        {
            _context.Mayor.Add(mayor);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
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
