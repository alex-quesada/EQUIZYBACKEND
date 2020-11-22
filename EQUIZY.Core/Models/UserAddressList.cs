using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class UserAddressList
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int AddressId { get; set; }
        public AppUser User { get; set; }
        public Address Address { get; set; }
        public byte Status { get; set; }
    }
}
