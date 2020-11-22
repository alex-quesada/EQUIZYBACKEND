using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class AppUserResource
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public string RoleName { get; set; }
    }
}
