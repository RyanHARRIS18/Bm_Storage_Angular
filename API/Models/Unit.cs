using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models
{
   public class Unit
   {
      [Display(Name = "Unit ID")]
      public int UnitID { get; set; }
      public int UnitNumber { get; set; }

      public int UnitTypeID { get; set; }

      public string UnitLocation { get; set; }

      public string UnitDescription {get; set;}

      public UnitType UnitType { get; set; }
      public ICollection<ContractFile> Contracts { get; set; }

    }
}