using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<TenantDTO>> GetTenantsAsync();
        Task<TenantDTO> GetTenantAsync(string username);
    }
}