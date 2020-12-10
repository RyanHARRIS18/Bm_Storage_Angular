using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime DateOfBirth { get; set; }

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

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;

        //(1) User can have many Contracts
        public ICollection<ContractFile> ContractFiles { get; set; }

        // public int GetAge()
        // {
        //     //Need to extend functionality to calculate age
        //     return DateOfBirth.CalculateAge();
        // }

    }
}