using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class Address
    {
        public Address()
        {
            AddressList = new Collection<UserAddressList>();
        }
        public int Id { get; set; }
        public int TypeAddressId { get; set; }
        public TypeAddress TypeAddress { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string OtherSigns { get; set; }
        public string ZipCode { get; set; }
        public byte Status { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<UserAddressList> AddressList { get; set; }
    }
}
