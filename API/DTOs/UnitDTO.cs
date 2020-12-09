using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UnitDTO
    {
      public string UnitID {get; set;}

      [Required]
      public string UnitNumber { get; set; }

      public string UnitLocation { get; set; }

      [Required]
      public string UnitTypeName { get; set; }

      public string UnitDescription {get; set;}

    }
}