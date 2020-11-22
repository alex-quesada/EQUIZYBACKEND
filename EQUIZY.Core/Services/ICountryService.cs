using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int id);
        Task<Country> CreateCountry(Country newCountry);
        Task UpdateCountry(Country countryToBeUpdated, Country country);
        Task DeleteCountry(Country country);
    }
}
