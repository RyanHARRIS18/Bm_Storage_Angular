using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UnitController : BaseApiController
    {

        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitController(IUnitRepository unitRepository, IMapper mapper)
        {
            _mapper = mapper;
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageUnitDTO>>> GetUnits()
        {
            var units = await _unitRepository.GetStorageUnitsAsync();
            var unitsToReturn = _mapper.Map<IEnumerable<TenantDTO>>(units);
            return Ok(units);
        }

        [HttpGet]
        public async Task<ActionResult<StorageUnitDTO>> GetUnits([Optional] int unitNumber, [Optional] string unitTypeName)
        {
            var unit = await _unitRepository.GetStorgeUnitAsync(unitNumber, unitTypeName);
            return _mapper.Map<StorageUnitDTO>(unit);
        }
    }

}