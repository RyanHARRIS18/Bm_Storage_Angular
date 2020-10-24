using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class TenantDTO
    {
            public int Id { get; set; }
        public string UserName { get; set; }


        public int Age { get; set; }

        public string KnownAs { get; set; }
      
        [Display(Name = "Gate Code")]
        public int GateCode { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; } 

        //(1) User can have many Contracts
        public ICollection<ContractFileDTO> ContractFiles { get; set; }
    }
}