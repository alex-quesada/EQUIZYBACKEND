using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class StateProvince
    {
        public StateProvince()
        {
            Cities = new Collection<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
