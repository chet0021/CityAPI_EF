using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class MayorRepository : IMayorRepository
    {
        private readonly CityInfoContext _context;

        public MayorRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddMayor(Mayor mayor)
        {
            _context.Mayor.Add(mayor);
        }

        public Mayor GetMayor(int mayorId)
        {
            return _context.Mayor.Where(c => c.Id == mayorId).FirstOrDefault();
        }

        public IEnumerable<Mayor> GetMayors()
        {
            return _context.Mayor.OrderBy(c => c.Name).ToList();
        }

        

        public void RemoveMayor(int mayorId)
        {
            var delMayor = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
            _context.Mayor.Remove(delMayor);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMayorInfo(int mayorId, Mayor mayor)
        {
            var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
            entity.Name = mayor.Name;
            entity.NickName = mayor.NickName;
            entity.Age = mayor.Age;
        }
    }
}
