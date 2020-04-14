using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using CityInfo.API.Resources;
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

        public IEnumerable<Mayor> GetMayors(MayorResources resourceParameter)
        {
            if (string.IsNullOrEmpty(resourceParameter.Gender) && string.IsNullOrEmpty(resourceParameter.NameSearch))
            {
                return _context.Mayor.OrderBy(c => c.Name).ToList();
            }
            var collection = _context.Mayor as IQueryable<Mayor>;

            if (!string.IsNullOrEmpty(resourceParameter.NameSearch) && string.IsNullOrEmpty(resourceParameter.Gender))
            {
                return collection.Where(c => c.Name.Contains(resourceParameter.NameSearch)).ToList();
            }

            if (!string.IsNullOrEmpty(resourceParameter.Gender) && string.IsNullOrEmpty(resourceParameter.NameSearch))
            {
                return collection.Where(c => c.Gender.ToLower() == resourceParameter.Gender.ToLower()).ToList();
            }

            if (!string.IsNullOrEmpty(resourceParameter.NameSearch))
            {
                return collection.Where(c => c.Name.Contains(resourceParameter.Gender) && c.Name.Contains(resourceParameter.NameSearch)).ToList();
            }
            return collection;
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
