using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EQUIZY.Core.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllWithStateProvince();
        Task<City> GetCityById(int id);
        Task<City> GetCityByName(string name);
        Task<IEnumerable<City>> GetCityByStateProvinceId(int stateProvinceId);
        Task<City> CreateCity(City newStateProvince);
        Task UpdateCity(City cityToBeUpdated, City city);
        Task DeleteCity(City city);
    }
}
