using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using CityInfo.API.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class MayorInfoRepository : IMayorInfoRepository
    {

        private readonly MayorInfoContext _context;

        public MayorInfoRepository(MayorInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Mayor> GetMayors(MayorParameters mayorParameters)
        {
            if (!String.IsNullOrEmpty(mayorParameters.Name)) 
            { 
                return _context.Mayor.Where(c => c.Name.Contains(mayorParameters.Name));
            }
            if (!String.IsNullOrEmpty(mayorParameters.Gender))
            {
                return _context.Mayor.Where(c => c.Gender.Equals(mayorParameters.Gender));
            }
            return _context.Mayor.OrderBy(c => c.Name).ToList();
        }

        public void CreateMayor(Mayor mayor)
        {
            _context.Mayor.Add(mayor);
        }

        public void DeleteMayor(int mayorId)
        {
            var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
            _context.Mayor.Remove(entity);
        }

        public Mayor GetMayor(int mayorId)
        {
            return _context.Mayor
                    .Where(m => m.Id == mayorId).FirstOrDefault();
        }


        public bool MayorExists(int mayorId)
        {
            return _context.Mayor.Any(m => m.Id == mayorId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMayor(int mayorId, Mayor city)
        {
            throw new NotImplementedException();
        }
    }
}
