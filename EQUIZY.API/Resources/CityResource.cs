using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class CityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateProvinceResource StateProvince { get; set; }
    }
}
