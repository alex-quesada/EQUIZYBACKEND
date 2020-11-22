using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Country> CreateCountry(Country newCountry)
        {
            await _unitOfWork.Countries
                .AddAsync(newCountry);
            await _unitOfWork.CommitAsync();
            return newCountry;
        }

        public async Task DeleteCountry(Country country)
        {
            _unitOfWork.Countries.Remove(country);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _unitOfWork.Countries.GetAllWithStatesProvincesAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _unitOfWork.Countries.GetByIdAsync(id);
        }

        public async Task UpdateCountry(Country countryToBeUpdated, Country country)
        {
            countryToBeUpdated.Name = country.Name;
            countryToBeUpdated.CountryCode = country.CountryCode;
            await _unitOfWork.CommitAsync();
        }
    }
}
