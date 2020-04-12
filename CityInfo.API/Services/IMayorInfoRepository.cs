using System;
using System.Collections.Generic;
using CityInfo.API.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMayorInfoRepository
    {
        IEnumerable<Mayor> GetCityMayors();

        Mayor GetCtMayors(int Id);

        bool MayorExists(int mayorId);

        bool Save();

        void CreateMayor(Mayor mayor);

        void UpdateMayor(int mayorId, Mayor mayor);

        void DeleteMayor(int mayorId);
    }
}
