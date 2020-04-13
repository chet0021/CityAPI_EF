using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<City> GetCities()
        {
            return _context.City.OrderBy(c => c.Name).ToList();
        }

       



        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.City.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.City
					.Where(c => c.Id == cityId).FirstOrDefault();
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

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
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

		public void CreateCity(City city)
		{
			_context.City.Add(city);
		}

		public void UpdateCity(int cityID, City city)
		{
			
		}

		public void DeleteCity(int cityID)
		{
			var entity = _context.City.FirstOrDefault(c => c.Id == cityID);
			_context.City.Remove(entity);
		}

        //MAYOR ACTIONS

        //GET ALL MAYORS

         public IEnumerable<Mayor> GetMayors()
        {
            return _context.Mayor.OrderBy(c => c.Name).ToList();
        }
        //GET MAYOR
        public Mayor GetMayor(int mayorId)
        {
            return _context.Mayor
                    .Where(c => c.Id == mayorId).FirstOrDefault();
        }
        //ADD MAYOR
        public void CreateMayor(Mayor mayor)
        {
            _context.Mayor.Add(mayor);
        }
        //Delete MAYOR
        public void DeleteMayor(int mayorId)
        {
            var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
            _context.Mayor.Remove(entity);
        }
        //UPDATE MAYOR
        //public void UpdateMayor(int mayorId,Mayor mayor)
        //{
        //    var entity = _context.Mayor.FirstOrDefault(c => c.Id == mayorId);
        //    entity = mayor;
        //    _context.Mayor.Update(entity);

        //}
        public void UpdateMayor(int mayorId, Mayor mayor)
        {

        }

    }
}
