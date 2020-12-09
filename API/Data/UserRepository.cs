using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TenantDTO> GetTenantAsync(string username)
        {
            return await _context.Users
            .Where(x => x.UserName == username)
           .ProjectTo<TenantDTO>(_mapper.ConfigurationProvider)
           .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TenantDTO>> GetTenantsAsync()
        {
            return await _context.Users
           .ProjectTo<TenantDTO>(_mapper.ConfigurationProvider)
           .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}