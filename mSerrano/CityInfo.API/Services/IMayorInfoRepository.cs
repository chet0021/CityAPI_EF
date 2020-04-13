using MayorInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mayorInfo.API.Services
{
    public interface IMayorInfoRepository
    {

        IEnumerable<Mayor> GetMayors();
        bool MayorExists(int mayorId);
        bool Save();
        void CreateMayor(Mayor mayor);
        void UpdateMayor(int mayorID, Mayor mayor);
        void DeleteMayor(int mayorID);
        
    }
}
