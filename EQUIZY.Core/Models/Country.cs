using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class Country
    {
        public Country()
        {
            StatesProvinces = new Collection<StateProvince>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public ICollection<StateProvince> StatesProvinces { get; set; }
    }
}
