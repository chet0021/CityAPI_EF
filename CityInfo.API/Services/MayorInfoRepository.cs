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
        private readonly MayorContext _context;
        private bool includeCity;

        public MayorInfoRepository(MayorContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public IEnumerable<Mayor> GetMayors()
        {
            return _context.Mayor.OrderBy(m => m.Id).ToList();
        }
        public Mayor GetMayor(int mayorId, bool includeCity)
        {
            if (includeCity)
            {
                return _context.Mayor.Include(m => m.Id == mayorId).Where(m => m.Id == mayorId).FirstOrDefault();
            }
            return _context.Mayor.Where(m => m.Id == mayorId).FirstOrDefault();
        }
        public City GetCityMayor(int mayorId, int cityId)
        {
            return _context.City.Where(c => c.MayorId == mayorId && c.Id == cityId).FirstOrDefault();
        }
        public IEnumerable<City> GetCityMayor(int mayorId)
        {
            return _context.City.Where(c => c.Id == mayorId);
        }
        public void AddCityMayor(int mayorId, City city)
        {
            var mayor = GetMayor(mayorId, false);
            mayor.City.Add(city);
        }
        public void UpdateCityMayor(int MyorId, City city)
        {

        }

        public void DeleteCity(City city)
        {
            _context.City.Remove(city);
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
        ////////////////////////////////////////////////////////////////////
        ///
        public Mayor GetMayorCity(int mayorId, bool IncludeCity)
        {
            if (includeCity)
            {
                return _context.Mayor.Include(m => m.Id == mayorId).Where(m => m.Id == mayorId).FirstOrDefault();
            }
            return _context.Mayor.Where(m => m.Id == mayorId).FirstOrDefault();
        }

        public IEnumerable<City> GetMayorCity(int mayorId)
        {
            throw new NotImplementedException();
        }

        public City GetMayorCity(int mayorId, int cityId)
        {
            throw new NotImplementedException();
        }

        public void Deletecity(City city)
        {
            throw new NotImplementedException();
        }

        object IMayorInfoRepository.GetMayor(int id, bool includeCity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMayor(int mayorID, object entityMayor)
        {
            throw new NotImplementedException();
        }
    }
}
