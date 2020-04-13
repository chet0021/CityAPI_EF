using CityInfo.API.Entities;
using System.Collections.Generic;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        bool CityExists(int cityId);
        void CreateCity(City city);
        void DeleteCity(int cityId);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointOfInterest);
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        IEnumerable<PointOfInterest> GetPointOfInterestsForCity(int cityId);
        bool Save();
        void UpdateCity(int cityId, City city);
        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
    }
}