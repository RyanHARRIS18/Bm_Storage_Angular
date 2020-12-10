using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("ContractFiles")]
    public class ContractFile
    {
        public int ContractFileId { get; set; }
        public string Url { get; set; }
        public string PublicID  {get; set;}

      public DateTime StartDate { get; set; }

      public DateTime? EndDate { get; set; }
      public static readonly DateTime END_OF_TIME = new DateTime(3000, 01, 01);
        public Unit Unit { get; set; }

        [Display(Name = "Tenant")]
        public AppUser User { get; set; }

   }
}
