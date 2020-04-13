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

        Mayor GetMayor(int Id);

        bool MayorExists(int Id);

        bool Save();

        void CreateMayor(Mayor mayor);

        void UpdateMayor(int Id, Mayor mayor);

        void DeleteMayor(int Id);
    }
}
