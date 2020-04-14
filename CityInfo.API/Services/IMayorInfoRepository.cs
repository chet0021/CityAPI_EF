using CityInfo.API.Entities;
using CityInfo.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMayorInfoRepository 
    {
        IEnumerable<Mayor> GetMayors(MayorResources resourceParameter);
        Mayor GetMayor(int mayorId);
        void CreateMayor(Mayor mayor);
        bool Save();
        void UpdateMayor(int mayorId, Mayor mayor);
        void DeleteMayor(int mayorId);
    }
}
