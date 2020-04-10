using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        bool CityExists(int cityId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);


        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);
        bool Save();
        void CreateCity(City city);
        void UpdateCity(int cityID, City city);
		void DeleteCity(int cityID);
	}
}
