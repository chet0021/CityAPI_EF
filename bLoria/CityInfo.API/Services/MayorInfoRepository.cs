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

        private readonly MayorInfoContext _context;

        public MayorInfoRepository(MayorInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Mayor> GetMayors()
        {
            return _context.MayorDTO.OrderBy(c => c.Name).ToList();
        }

        public Mayor GetMayor(int Id)
        {
            return _context.MayorDTO
                    .Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool MayorExists(int Id)
        {
            return _context.MayorDTO.Any(c => c.Id == Id);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateMayor(Mayor mayor)
        {
            _context.MayorDTO.Add(mayor);
        }

        public void UpdateMayor(int Id, Mayor mayor)
        {

        }

        public void DeleteMayor(int Id)
        {
            var entity = _context.MayorDTO.FirstOrDefault(c => c.Id == Id);
            _context.MayorDTO.Remove(entity);
        }

    }
}
