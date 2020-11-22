using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Services.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<City> CreateCity(City newCity)
        {
            await _unitOfWork.Cities.AddAsync(newCity);
            await _unitOfWork.CommitAsync();
            return newCity;
        }

        public async Task DeleteCity(City city)
        {
            _unitOfWork.Cities.Remove(city);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<City>> GetAllWithStateProvince()
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _unitOfWork.Cities.GetWithStateProvinceByIdAsync(id);
        }

        public async Task<City> GetCityByName(string name)
        {
            return await _unitOfWork.Cities.GetWithStateProvinceByNameAsync(name);
        }

        public async Task<IEnumerable<City>> GetCityByStateProvinceId(int stateProvinceId)
        {
            return await _unitOfWork.Cities.GetAllWithStateProvinceByStateProvinceIdAsync(stateProvinceId);
        }

        public async Task UpdateCity(City cityToBeUpdated, City city)
        {
            cityToBeUpdated.Name = city.Name;
            cityToBeUpdated.StateProvinceId = city.StateProvinceId;
            await _unitOfWork.CommitAsync();
        }
    }
}
