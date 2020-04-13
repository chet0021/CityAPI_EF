using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mayorInfo.API.Services;
using MayorInfo.API.Contexts;
using MayorInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MayorInfo.API.Services
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
            return _context.Mayor.OrderBy(c => c.Name).ToList();
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

        public void UpdateMayor(int mayorID, Mayor mayor)
        {

        }

        public void DeleteMayor(int mayorID)
        {
            var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorID);
            _context.Mayor.Remove(entity);
        }
    }
}
