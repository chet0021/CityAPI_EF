using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IMayorInfoRepository
    {
        IEnumerable<Mayor> GetMayors();

        Mayor GetMayor(int mayorId);


        bool MayorExists(int mayorId);


        bool Save();

        void CreateMayor(Mayor mayor);

        void UpdateMayor(int mayorId, Mayor city);
        void DeleteMayor(int mayorId);
    }
}
