using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateProvinceId { get; set; }
        public StateProvince StateProvince { get; set; }
    }
}
