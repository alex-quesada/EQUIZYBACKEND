using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class AddressResource
    {
        public int Id { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string OtherSigns { get; set; }
        public string ZipCode { get; set; }
        public byte Status { get; set; }
        public CityResource City { get; set; }
        public TypeAddressResource TypeAddress { get; set; }
    }
}
