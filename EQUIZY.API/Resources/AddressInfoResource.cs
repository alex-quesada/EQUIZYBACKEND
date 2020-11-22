using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class AddressInfoResource
    {
        public IEnumerable<AddressResource> AddressesListDTO { get; set; }
        public IEnumerable<CountryResource> CountriesListDTO { get; set; }
        public IEnumerable<TypeAddressResource> TypeAddressesDTO { get; set; }
    }
}
