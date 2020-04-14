using CityInfo.API.Entities;
using CityInfo.API.ResourceParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMayorRepository
    {
        IEnumerable<Mayor> GetMayors(MayorResourceParameter mayorParamerter);
        Mayor GetMayor(int mayorId);
        void AddMayor(Mayor mayor);
        void UpdateMayorInfo(int mayorId, Mayor mayor);
        void RemoveMayor(int mayorId);
        bool Save();
        
    }
}
