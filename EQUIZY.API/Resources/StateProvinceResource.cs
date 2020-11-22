using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class StateProvinceResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryResource Country { get; set; }
    }
}
