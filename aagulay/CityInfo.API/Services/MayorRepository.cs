using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CityInfo.API.ResourceParams;

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

        public IEnumerable<Mayor> GetMayors(MayorResourceParameter mayorParameters)
        {
            if (string.IsNullOrEmpty(mayorParameters.NameSearch) && string.IsNullOrEmpty(mayorParameters.GenderFilter.ToString())) {

                return _context.Mayor.OrderBy(c => c.Name).ToList();

            }
           
            var collection = _context.Mayor as IQueryable<Mayor>;

            if (!string.IsNullOrEmpty(mayorParameters.NameSearch)){
                return collection.Where(p => p.Name.Contains(mayorParameters.NameSearch)
                || p.NickName.Contains(mayorParameters.NameSearch));
            }
            if (!string.IsNullOrEmpty(mayorParameters.GenderFilter.ToString())) {
                collection = collection.Where(p => p.Gender.Equals(mayorParameters.GenderFilter));
            }

            return collection;

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
        }
    }
}
