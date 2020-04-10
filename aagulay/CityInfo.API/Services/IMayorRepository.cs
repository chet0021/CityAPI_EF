using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMayorRepository
    {
        IEnumerable<Mayor> GetMayors();
        Mayor GetMayor(int mayorId);
        void AddMayor(Mayor mayor);
        void UpdateMayorInfo(int mayorId, Mayor mayor);
        void RemoveMayor(int mayorId);
        bool Save();
        
    }
}
