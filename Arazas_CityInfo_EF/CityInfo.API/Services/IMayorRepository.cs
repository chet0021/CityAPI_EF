using CityInfo.API.Entities;
using System.Collections.Generic;

namespace CityInfo.API.Services
{
    public interface IMayorRepository
    {
        void AddMayor(Mayor mayor);
        void DeleteMayor(int mayorId);
        Mayor GetMayor(int mayorId);
        IEnumerable<Mayor> GetMayors();
        bool IsMayorExists(int mayorId);
        void Save();
        void UpdateMayor(int mayorId, Mayor mayor);
    }
}