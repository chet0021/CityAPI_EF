using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    interface IMayorInfoRepository
    {
        IEnumerable<Mayor> GetMayors();
        Mayor GetMayorCity(int mayorId, bool IncludeCity);
        IEnumerable<City> GetMayorCity(int mayorId);
        City GetMayorCity(int mayorId, int cityId);

        void AddCityMayor(int mayorId, City city);
        void UpdateCityMayor(int mayorId, City city);
        void Deletecity(City city);
        bool Save();

        void CreateMayor(Mayor mayor);
        void UpdateMayor(int mayorID, Mayor mayor);
        void DeleteMayor(int mayorID);
        object GetMayor(int id, bool includeCity);
        void UpdateMayor(int mayorID, object entityMayor);
    }
}
