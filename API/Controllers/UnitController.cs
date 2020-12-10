using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper.QueryableExtensions;

namespace API.Controllers
{
    public class UnitController : BaseApiController
    {
        private readonly DataContext _context;

        public UnitController(DataContext context)
        {
         _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            return await _context.Units
            .Include(x => x.UnitType)
           .ToListAsync();
        }

        // Get a unit by its number
        [HttpGet("{unitNumber}")]
        public async Task<ActionResult<Unit>> GetUnitsByNumber(int unitNumber)
        {
             return await _context.Units
             .Where(x => x.UnitNumber == unitNumber)
            .SingleOrDefaultAsync();
        }

        // Get a units by Type
         [HttpGet("{unitTypeName}")]
         public async Task<ActionResult<IEnumerable<Unit>>> GetUnitsByType(string unitTypeName)
        {
             return await _context.Units
             .Include(ut => ut.UnitType)
             .Where(x => x.UnitType.UnitTypeName == unitTypeName)
            .ToListAsync();
        }

           // Get a units by Type
         [HttpGet("{Occupancy}")]
         public async Task<ActionResult<IEnumerable<Unit>>> GetUnitsByOccupancy(string ? emptyUnits, string ? occupiedUnits)
        {
            if(string.IsNullOrEmpty(emptyUnits)){
             return await _context.Units
             .Include(ut => ut.UnitType)
             .Where(x => x.Occupancy == false)
            .ToListAsync();
            }

             if(string.IsNullOrEmpty(occupiedUnits)){
             return await _context.Units
             .Include(ut => ut.UnitType)
             .Where(x => x.Occupancy == true)
            .ToListAsync();
            }
            
            return(null);
        }

        //Get units Types
         [HttpGet("UnitTypes")]
         public async Task<ActionResult<IEnumerable<UnitType>>> GetUnitTypes()
        {
             return await _context.UnitType
            .ToListAsync();
        }

      [HttpPost("new")]
        public async Task<ActionResult<Unit>> CreateUnit(UnitDTO unit)
        {
           System.Diagnostics.Debug.WriteLine(unit);

            var UnitNumber = Convert.ToInt32(unit.UnitNumber);


             UnitType unitUnitType = await _context.UnitType
             .Where(x => x.UnitTypeName == unit.UnitTypeName)
            .SingleOrDefaultAsync();

            Unit unitReturned = await _context.Units.Where(e => e.UnitNumber == UnitNumber).SingleOrDefaultAsync();
            if (!(unitReturned == null))
            {
            return BadRequest("Unit Number alread exists " + unit.UnitNumber);
            }
            else
            {
               var newUnit = new Unit 
                {
                    UnitNumber             = UnitNumber,
                    UnitLocation           = unit.UnitLocation,   
                    UnitTypeID             = unitUnitType.UnitTypeID,   
                    UnitDescription        = unit.UnitDescription ,
                    UnitSpecificImageUrl   = unitUnitType.UnitTypeImageUrl
                };
                _context.Add(newUnit);
                await _context.SaveChangesAsync();
             }
   
             return Ok(await _context.Units
             .Where(x => x.UnitNumber == UnitNumber)
              .Include(ut => ut.UnitType)
              .SingleOrDefaultAsync());
        }

     [HttpPut("edit")]
        public async Task<ActionResult<Unit>> EditUnit(UnitDTO unit)
        {
            var NewUnitNumber = Convert.ToInt32(unit.UnitNumber);
            var UnitID = Convert.ToInt32(unit.UnitID);

            UnitType unitUnitType = await _context.UnitType
            .Where(x => x.UnitTypeName == unit.UnitTypeName)
            .SingleOrDefaultAsync();
        
         Unit unitReturned = await _context.Units.Where(e => e.UnitID == UnitID).SingleOrDefaultAsync();

            if (unitReturned != null)
            {
                   Unit unitToUpdate = await _context.Units
                    .Where(x => x.UnitID == UnitID)
                    .Include(ut => ut.UnitType)
                    .SingleOrDefaultAsync();                

                   unitToUpdate.UnitID                 = unitReturned.UnitID;
                   unitToUpdate.UnitNumber             = NewUnitNumber;
                   unitToUpdate.UnitLocation           = unit.UnitLocation; 
                   unitToUpdate.UnitTypeID             = unitUnitType.UnitTypeID; 
                   unitToUpdate.UnitDescription        = unit.UnitDescription;
                   unitToUpdate.UnitSpecificImageUrl   = unitUnitType.UnitTypeImageUrl;

                try
                {
                _context.Update(unitToUpdate);
                await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitNumberExists(NewUnitNumber))
                    {
                        return BadRequest("concurrency exception.");
                    }
                    else
                    {
                         return BadRequest("Other Error.");
                    }
                }
            
            return Ok(await _context.Units
             .Where(x => x.UnitNumber == NewUnitNumber)
              .Include(ut => ut.UnitType)
              .SingleOrDefaultAsync());
            }
            else
            {
            return BadRequest("Unit did not exist.");
            }

          
           
        }

  // POST: Units/Delete/5
        [HttpDelete("{unitID}")]
        public async Task<ActionResult> Delete(int id)
        {
            //  var UnitNumber = Convert.ToInt32(id);

            var unit = await _context.Units.Where(e => e.UnitID == id).SingleOrDefaultAsync();
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
           return Ok();
        }

        private bool UnitNumberExists(int id)
        {
            var unitReturned = _context.Units.Where(e => e.UnitNumber == id).SingleOrDefaultAsync();
            if((unitReturned.Id).ToString() == null) {
            return false;
            }
            else{
            return true;
            }



        }

    }

}