using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class MayorInfoRepository
    {
        private readonly CityInfoContext _context;

        public MayorInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<City> GetMayors()
        {
            return _context.City.OrderBy(c => c.Name).ToList();
        }

        

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest
               .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
                          .Where(p => p.CityId == cityId).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _context.City.Any(c => c.Id == cityId);
        }

        
        private object GetCity(int cityId, bool v)
        {
            throw new NotImplementedException();
        }

        public void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        

        public void UpdateCity(int cityID, City city)
        {

        }

        public void DeleteMayor(int mayorID)
        {
            var entity = _context.City.FirstOrDefault(c => c.Id == mayorID);
            _context.City.Remove(entity);
        }
    }
}
