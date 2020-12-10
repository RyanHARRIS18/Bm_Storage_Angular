using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;


namespace API.Models
{
   public class StorageUnitDTO
   {
      public int UnitID { get; set; }
      public int UnitNumber { get; set; }

      public int UnitTypeID { get; set; }

      public string UnitLocation { get; set; }

      public string UnitTypeName { get; set; }

      public string UnitDescription {get; set;}


      // Feet Wide
      public decimal Width { get; set; }

      // Feet Deep
      public decimal Depth { get; set; }

      // Feet Tall
      public decimal Height { get; set; }

      public decimal Price { get; set; }

      public bool available {get; set;}

    }
}