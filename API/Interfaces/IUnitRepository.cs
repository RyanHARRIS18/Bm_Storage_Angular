using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Interfaces
{
    public interface IUnitRepository
    {
        void Update(Unit unit);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Unit>> GetUnitsAsync();
        Task<Unit> GetUnitByIdAsync(int id);
        Task<IEnumerable<Unit>>  GetUnitsByUnitTypeOrNumberAsync(string unitTypeName, int unitNumber);
        Task<StorageUnitDTO> GetStorgeUnitAsync([Optional] int unitNumber , [Optional] string unitTypeName);
        Task<IEnumerable<StorageUnitDTO>> GetStorageUnitsAsync();

    }
}