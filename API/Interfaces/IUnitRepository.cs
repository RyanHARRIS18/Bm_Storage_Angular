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
        Task<IEnumerable<StorageUnitDTO>> GetStorageUnitsAsync();
        Task<StorageUnitDTO> GetStorgeUnitAsync([Optional] int unitNumber , [Optional] string unitTypeName);
    }
}
