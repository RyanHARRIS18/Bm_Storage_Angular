using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UnitRepository : IUnitRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Update(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Unit>> GetUnitsAsync()
        {
            return await _context.Units
            .Include(p => p.UnitType)
            .ToListAsync();
        }

        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task<IEnumerable<Unit>> GetUnitsByUnitTypeOrNumberAsync(string unitTypeName, int unitNumber)
        {
             return await _context.Units.Where(x => x.UnitNumber == unitNumber || x.UnitType.UnitTypeName == unitTypeName)
                                      .Include(p => p.UnitType)
                                      .ToListAsync();

           
        }

     

         public async Task<StorageUnitDTO> GetStorgeUnitAsync(int unitNumber , string unitTypeName)
         {
             return await _context.Units
             .Where(x => x.UnitNumber == unitNumber || x.UnitType.UnitTypeName == unitTypeName)
            .ProjectTo<StorageUnitDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
         }

        public async  Task<IEnumerable<StorageUnitDTO>> GetStorageUnitsAsync()
        {
            return await _context.Units
           .ProjectTo<StorageUnitDTO>(_mapper.ConfigurationProvider)
           .ToListAsync();
        }

       

     

 

     

   
    }
}