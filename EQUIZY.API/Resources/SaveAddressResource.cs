using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class SaveAddressResource
    {
        public int StateId { get; set; }
        public int TypeAddressId { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string OtherSigns { get; set; }
        public string ZipCode { get; set; }
        public byte Status { get; set; }
        public string CityName { get; set; }
    }
}
