using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public byte Status { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<UserAddressList> AddressList { get; set; }
    }
}
