using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class TypeAddress
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
